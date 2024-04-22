package com.gameproject.gamebackend.service;

import org.springframework.beans.factory.annotation.Autowired;
import com.gameproject.gamebackend.entity.GameData;
import org.springframework.stereotype.Service;

import java.util.List;

public interface GameDataService {
    public GameData findByUsername(String username);

    public List<GameData> findGameDataAll();

    public String setDataIndS(GameData gameData);

    public String setDataIndL(GameData gameData);

    public List<GameData> getRankingS();

    public List<GameData> getRankingL();

    public List<GameData> getDataIndS(String username);

    public List<GameData> getDataIndL(String username);
}
