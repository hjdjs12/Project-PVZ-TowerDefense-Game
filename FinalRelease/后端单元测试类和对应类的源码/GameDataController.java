package com.gameproject.gamebackend.controller;

import com.gameproject.gamebackend.entity.GameData;
import com.gameproject.gamebackend.service.GameDataService;
import com.google.gson.Gson;
import lombok.RequiredArgsConstructor;
import org.apache.ibatis.annotations.Param;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestBody;
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
    public String getDataIndS(GameData gameData) {
        List<GameData> list = gameDataService.getDataIndS(gameData.getUsername());
        Gson gson = new Gson();
        return gson.toJson(list);
    }

    @GetMapping("getDataIndL")
    public String getDataIndL(GameData gameData) {
        List<GameData> list = gameDataService.getDataIndL(gameData.getUsername());
        Gson gson = new Gson();
        return gson.toJson(list);
    }

    @GetMapping("verLogin")
    public String verLogin(GameData gameData) {
        if (gameDataService.verLogin(gameData)) {
            return "登入成功";
        }
        return "登入失败";
    }

    @GetMapping("register")
    public String register(GameData gameData) {
        if (gameDataService.register(gameData)) {
            return "注册成功";
        }
        return "注册失败";
    }
}
