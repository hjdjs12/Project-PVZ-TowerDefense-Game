package com.gameproject.gamebackend.mapper;

import com.gameproject.gamebackend.entity.GameData;
import org.apache.ibatis.annotations.Mapper;
import org.springframework.stereotype.Repository;

import java.util.List;

@Mapper
@Repository
public interface GameDataMapper {
    // 通过用户名获取相应的数据
    public GameData findByUsername(String username);
    // 返回整个数据库的数据
    public List<GameData> findGameDataAll();

    public Integer setDataIndS(GameData gameData);

    public Integer setDataIndL(GameData gameData);

    public List<GameData> getRankingS();

    public List<GameData> getRankingL();

    public List<GameData> getDataIndS(String username);

    public List<GameData> getDataIndL(String username);
}
