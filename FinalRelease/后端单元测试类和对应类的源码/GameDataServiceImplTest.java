package com.gameproject.gamebackend.service.impl;

import com.gameproject.gamebackend.entity.GameData;
import com.gameproject.gamebackend.mapper.GameDataMapper;
import com.gameproject.gamebackend.service.GameDataService;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
class GameDataServiceImplTest {

    // 正确的输入
    String username = "juliano";
    String password = "123456";
    String phone = "12345678901";
    String email = "correct@qq.com";
    // 错误输入
    String w_password = "123123";
    String username2 = "anonymous";
    String username3 = "random";
    String w_phone1 = "123456";
    String w_phone2 = "1234567890123";
    String w_email1 = "wrong@@qq.com";
    String w_email2 = "wrong@outlook.com";

//    @BeforeEach
//    void setUp() {
//    }
//
//    @AfterEach
//    void tearDown() {
//    }
//////////////////////////////////// 项目内未曾使用的函数
//    @Test
//    void findByUsername() {
//    }
//
//    @Test
//    void findGameDataAll() {
//    }
//////////////////////////////////// 项目内用到的函数
    GameData gameData = new GameData();

    @Autowired
    GameDataService gameDataService;

    @Test
    void setDataIndS() {
        // 用户不存在
        gameData.setUsername(username2);
        gameData.setRecord(10000);
        gameData.setDate("2023-12-31 23:59:59");
        assertEquals("玩家不存在", gameDataService.setDataIndS(gameData));
        // 成功
        gameData.setUsername(username);
        assertEquals("添加成功！", gameDataService.setDataIndS(gameData));
    }

    @Test
    void setDataIndL() {
        // 用户不存在
        gameData.setUsername(username2);
        gameData.setRecord(11);
        gameData.setEleft(20);
        assertEquals("玩家不存在", gameDataService.setDataIndL(gameData));
        // 成功
        gameData.setUsername(username);
        assertEquals("添加成功！", gameDataService.setDataIndL(gameData));
    }

    // 数据库有记录，不可能为空
    @Test
    void getRankingS() {
        assertNotNull(gameDataService.getRankingS());
    }
    // 数据库有记录，不可能为空
    @Test
    void getRankingL() {
        assertNotNull(gameDataService.getRankingL());
    }

    @Test
    void getDataIndS() {
        // 数据库有记录，不可能为空
        assertNotNull(gameDataService.getDataIndS(username));
        // 不存在的用户名，数据库不可能有记录
        List<GameData> result = gameDataService.getDataIndS(username2);
        if (result.isEmpty()) result = null;
        assertNull(result);
    }

    @Test
    void getDataIndL() {
        // 数据库有记录，不可能为空
        assertNotNull(gameDataService.getDataIndL(username));
        // 不存在的用户名，数据库不可能有记录
        List<GameData> result = gameDataService.getDataIndL(username2);
        if (result.isEmpty()) result = null;
        assertNull(result);
    }

    @Test
    void verLogin() {
        // 用户名不存在
        gameData.setUsername(username2);
        gameData.setPassword(password);
        assertFalse(gameDataService.verLogin(gameData));
        // 用户名和密码都正确
        gameData.setUsername(username);
        assertTrue(gameDataService.verLogin(gameData));
        // 密码错误
        gameData.setPassword(w_password);
        assertFalse(gameDataService.verLogin(gameData));
    }

    @Test
    void register() {
        // 用户名存在
        gameData.setUsername(username);
        gameData.setPassword(password);
        gameData.setPhone(phone);
        gameData.setEmail(email);
        assertFalse(gameDataService.register(gameData));
        // 错误的手机格式
        gameData.setUsername(username3);
        gameData.setPhone(w_phone1);
        assertFalse(gameDataService.register(gameData));
        gameData.setPhone(w_phone2);
        assertFalse(gameDataService.register(gameData));
        // 错误的邮箱格式
        gameData.setPhone(phone);
        gameData.setEmail(w_email1);
        assertFalse(gameDataService.register(gameData));
        gameData.setEmail(w_email2);
        assertFalse(gameDataService.register(gameData));
        // 成功注册
        gameData.setEmail(email);
        assertTrue(gameDataService.register(gameData));
    }
}