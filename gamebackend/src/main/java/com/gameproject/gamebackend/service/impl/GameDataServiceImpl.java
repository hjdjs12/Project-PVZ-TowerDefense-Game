package com.gameproject.gamebackend.service.impl;

import com.gameproject.gamebackend.mapper.GameDataMapper;
import com.gameproject.gamebackend.entity.GameData;
import com.gameproject.gamebackend.service.GameDataService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.sql.Date;
import java.text.SimpleDateFormat;
import java.util.List;

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
        gameData.setDateString(gameData.getDateString().replace('T', ' '));
        Integer integer = gameDataMapper.setDataIndS(gameData);
        System.out.println(integer);
        if (integer > 0) return "添加成功！";
        return "添加失败！";
    }

    @Override
    public String setDataIndL(GameData gameData) {
        Integer integer = gameDataMapper.setDataIndL(gameData);
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
}
