package com.gameproject.gamebackend.controller;

import com.gameproject.gamebackend.entity.GameData;
import com.gameproject.gamebackend.service.GameDataService;
import com.google.gson.Gson;
import org.apache.ibatis.annotations.Param;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/gamedata")
public class GameDataController {

    @Autowired
    private GameDataService gameDataService;
    /*
    @GetMapping("getByUsername")
    public GameData getByUsername(@Param("username") String username) {
        GameData gameData = gameDataService.findByUsername(username);
        return gameData;
    }
    */
    @GetMapping("getByUsernameJson")
    public String getByUsernameJson(@Param("username") String username) {
        GameData gameData = gameDataService.findByUsername(username);
        Gson gson = new Gson();
        return gson.toJson(gameData);
    }
    /*
    @GetMapping("getAll")
    public List<GameData> getAll() {
        List<GameData> list = gameDataService.findGameDataAll();
        return list;
    }
    */
    @GetMapping("getAllJson")
    public String getAllJson() {
        List<GameData> list = gameDataService.findGameDataAll();
        Gson gson = new Gson();
        return gson.toJson(list);
    }
    // 用到的接口
    @GetMapping("setDataIndS")
    public String setGameDataS(GameData gameData) {
        return gameDataService.setDataIndS(gameData);
    }

    @GetMapping("setDataIndL")
    public String setGameDataL(GameData gameData) {
        return gameDataService.setDataIndL(gameData);
    }

    @GetMapping("getRankingS")
    public String getRankingS() {
        List<GameData> list = gameDataService.getRankingS();
        Gson gson = new Gson();
        return gson.toJson(list);
    }

    @GetMapping("getRankingL")
    public String getRankingL() {
        List<GameData> list = gameDataService.getRankingL();
        Gson gson = new Gson();
        return gson.toJson(list);
    }

    @GetMapping("getDataIndS")
    public String getDataIndS(@Param("username") String username) {
        List<GameData> list = gameDataService.getDataIndS(username);
        Gson gson = new Gson();
        return gson.toJson(list);
    }

    @GetMapping("getDataIndL")
    public String getDataIndL(@Param("username") String username) {
        List<GameData> list = gameDataService.getDataIndL(username);
        Gson gson = new Gson();
        return gson.toJson(list);
    }
}
