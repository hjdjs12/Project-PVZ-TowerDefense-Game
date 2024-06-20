package com.gameproject.gamebackend.service.impl;

import com.gameproject.gamebackend.mapper.GameDataMapper;
import com.gameproject.gamebackend.entity.GameData;
import com.gameproject.gamebackend.service.GameDataService;
import org.apache.ibatis.jdbc.Null;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.sql.Date;
import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Objects;

@Service
public class GameDataServiceImpl implements GameDataService {

    @Autowired
    private GameDataMapper gameDataMapper;

    @Override
    public GameData findByUsername(String username) {
        return gameDataMapper.findByUsername(username);
    }

    @Override
    public List<GameData> findGameDataAll() {
        return gameDataMapper.findGameDataAll();
    }

    @Override
    public String setDataIndS(GameData gameData) {
        if (!(gameDataMapper.isExisted(gameData.getUsername()) == 1)) return "玩家不存在";
        gameData.setDate(gameData.getDate().replace('T', ' '));
        Integer integer = gameDataMapper.setDataIndS(gameData);
        // 检测数据库操作是否有问题
        if (integer > 0) return "添加成功！";
        return "添加失败！";
    }

    @Override
    public String setDataIndL(GameData gameData) {
        if (!(gameDataMapper.isExisted(gameData.getUsername()) == 1)) return "玩家不存在";
        Integer integer = gameDataMapper.setDataIndL(gameData);
        // 检测数据库操作是否有问题
        if (integer > 0) return "添加成功！";
        return "添加失败！";
    }

    @Override
    public List<GameData> getRankingS() {
        return gameDataMapper.getRankingS();
    }

    @Override
    public List<GameData> getRankingL() {
        return gameDataMapper.getRankingL();
    }

    @Override
    public List<GameData> getDataIndS(String username) {
        return gameDataMapper.getDataIndS(username);
    }

    @Override
    public List<GameData> getDataIndL(String username) {
        return gameDataMapper.getDataIndL(username);
    }

    @Override
    public boolean verLogin(GameData gameData) {
        if (!(gameDataMapper.isExisted(gameData.getUsername()) == 1)) return false;
        GameData rGameData = gameDataMapper.verLogin(gameData.getUsername());
        //System.out.println(gameData);
        //System.out.println(rGameData.getPassword());
        return Objects.equals(rGameData.getPassword(), gameData.getPassword());
    }

    @Override
    public boolean register(GameData gameData) {
        // 用户名已经存在
        if (gameDataMapper.isExisted(gameData.getUsername()) == 1) return false;
        // 手机号码格式错误
        if (gameData.getPhone().length() != 11) return false;
        // 邮箱格式错误
        if (gameData.getEmail().isEmpty()) return false;
        if (!gameData.getEmail().contains("@qq.com")) return false;
        if (gameData.getEmail().indexOf('@') != gameData.getEmail().lastIndexOf('@')) return false;
        Integer integer = gameDataMapper.register(gameData);
        return integer > 0;
    }
}
