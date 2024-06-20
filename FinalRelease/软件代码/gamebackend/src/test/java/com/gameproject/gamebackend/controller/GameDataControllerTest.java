package com.gameproject.gamebackend.controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.gameproject.gamebackend.entity.GameData;
import com.gameproject.gamebackend.service.GameDataService;
import mockit.Expectations;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.runner.RunWith;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@SpringBootTest
@AutoConfigureMockMvc
class GameDataControllerTest {
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
//    @Autowired
//    GameDataController gameDataController;

    GameData gameData = new GameData();

//    @Test
//    void setGameDataS() {
//        // 用户不存在
//        gameData.setUsername(username2);
//        gameData.setRecord(10000);
//        gameData.setDate("2023-12-31 23:59:59");
//        assertEquals("玩家不存在", gameDataController.setGameDataS(gameData));
//        // 成功
//        gameData.setUsername(username);
//        assertEquals("添加成功！", gameDataController.setGameDataS(gameData));
//    }
//
//    @Test
//    void setGameDataL() {
//        // 用户不存在
//        gameData.setUsername(username2);
//        gameData.setRecord(11);
//        gameData.setEleft(20);
//        assertEquals("玩家不存在", gameDataController.setGameDataL(gameData));
//        // 成功
//        gameData.setUsername(username);
//        assertEquals("添加成功！", gameDataController.setGameDataL(gameData));
//    }
//
//    @Test
//    void getRankingS() {
//        assertNotNull(gameDataController.getRankingS());
//    }
//
//    @Test
//    void getRankingL() {
//        assertNotNull(gameDataController.getRankingL());
//    }
//
//    @Test
//    void getDataIndS() {
//        gameData.setUsername(username);
//        assertNotNull(gameDataController.getDataIndS(gameData));
//        gameData.setUsername(username2);
//        assertEquals("[]", gameDataController.getDataIndS(gameData));
//    }
//
//    @Test
//    void getDataIndL() {
//        gameData.setUsername(username);
//        assertNotNull(gameDataController.getDataIndL(gameData));
//        gameData.setUsername(username2);
//        assertEquals("[]", gameDataController.getDataIndL(gameData));
//    }
//
//    @Test
//    void verLogin() {
//        // 用户名不存在
//        gameData.setUsername(username2);
//        gameData.setPassword(password);
//        assertEquals("登入失败", gameDataController.verLogin(gameData));
//        // 用户名和密码都正确
//        gameData.setUsername(username);
//        assertEquals("登入成功", gameDataController.verLogin(gameData));
//        // 密码错误
//        gameData.setPassword(w_password);
//        assertEquals("登入失败", gameDataController.verLogin(gameData));
//    }
//
//    @Test
//    void register() {
//        // 用户名存在
//        gameData.setUsername(username);
//        gameData.setPassword(password);
//        gameData.setPhone(phone);
//        gameData.setEmail(email);
//        assertEquals("注册失败", gameDataController.register(gameData));
//        // 错误的手机格式
//        gameData.setUsername(username3);
//        gameData.setPhone(w_phone1);
//        assertEquals("注册失败", gameDataController.register(gameData));
//        gameData.setPhone(w_phone2);
//        assertEquals("注册失败", gameDataController.register(gameData));
//        // 错误的邮箱格式
//        gameData.setPhone(phone);
//        gameData.setEmail(w_email1);
//        assertEquals("注册失败", gameDataController.register(gameData));
//        gameData.setEmail(w_email2);
//        assertEquals("注册失败", gameDataController.register(gameData));
//        // 成功注册
//        gameData.setEmail(email);
//        assertEquals("注册成功", gameDataController.register(gameData));
//    }

    @Autowired
    MockMvc mockMvc;

//    @MockBean
//    GameDataController gameDataController;

    @Autowired
    GameDataController gameDataController;

    @Test
    void setGameDataS() throws Exception{
        // 用户不存在
        mockMvc.perform(get("/gamedata/setDataIndS")
                        .param("username", username2)
                        .param("record", String.valueOf(10000))
                        .param("date", "2023-12-31 23:59:59"))
                .andExpect(content().string("玩家不存在"));
        // 成功
        mockMvc.perform(get("/gamedata/setDataIndS")
                        .param("username", username)
                        .param("record", String.valueOf(10000))
                        .param("date", "2023-12-31 23:59:59"))
                .andExpect(content().string("添加成功！"));
    }

    @Test
    void setGameDataL() throws Exception{
        // 用户不存在
        mockMvc.perform(get("/gamedata/setDataIndL")
                        .param("username", username2)
                        .param("record", String.valueOf(11))
                        .param("eleft", String.valueOf(20)))
                .andExpect(content().string("玩家不存在"));
        // 成功
        mockMvc.perform(get("/gamedata/setDataIndL")
                        .param("username", username)
                        .param("record", String.valueOf(11))
                        .param("eleft", String.valueOf(20)))
                .andExpect(content().string("添加成功！"));
    }

    @Test
    void getRankingS() throws Exception{
        MvcResult mvcResult = mockMvc.perform(get("/gamedata/getRankingS"))
                .andReturn();
        MockHttpServletResponse mockHttpServletResponse = mvcResult.getResponse();
        String result = mockHttpServletResponse.getContentAsString();
        assertNotEquals("[]", result);
    }

    @Test
    void getRankingL() throws Exception{
        MvcResult mvcResult = mockMvc.perform(get("/gamedata/getRankingL"))
                .andReturn();
        MockHttpServletResponse mockHttpServletResponse = mvcResult.getResponse();
        String result = mockHttpServletResponse.getContentAsString();
        assertNotEquals("[]", result);
    }

    @Test
    void getDataIndS() throws Exception{
        MvcResult mvcResult = mockMvc.perform(get("/gamedata/getDataIndS")
                .param("username", username))
                .andReturn();
        MockHttpServletResponse mockHttpServletResponse = mvcResult.getResponse();
        String result = mockHttpServletResponse.getContentAsString();
        assertFalse(result.isEmpty());

        mvcResult = mockMvc.perform(get("/gamedata/getDataIndS")
                        .param("username", username2))
                .andReturn();
        mockHttpServletResponse = mvcResult.getResponse();
        result = mockHttpServletResponse.getContentAsString();
        assertEquals("[]", result);
    }

    @Test
    void getDataIndL() throws Exception{
        MvcResult mvcResult = mockMvc.perform(get("/gamedata/getDataIndL")
                        .param("username", username))
                .andReturn();
        MockHttpServletResponse mockHttpServletResponse = mvcResult.getResponse();
        String result = mockHttpServletResponse.getContentAsString();
        assertFalse(result.isEmpty());

        mvcResult = mockMvc.perform(get("/gamedata/getDataIndL")
                        .param("username", username2))
                .andReturn();
        mockHttpServletResponse = mvcResult.getResponse();
        result = mockHttpServletResponse.getContentAsString();
        assertEquals("[]", result);
    }

    @Test
    public void verLogin() throws Exception{
//        gameData.setUsername(username);
//        gameData.setPassword(password);
        //when(gameDataController.verLogin(gameData)).thenReturn("1");

        mockMvc.perform(get("/gamedata/verLogin")
                        .param("username", username)
                        .param("password", password))
                .andExpect(content().string("登入成功"));

        mockMvc.perform(get("/gamedata/verLogin")
                        .param("username", username2)
                        .param("password", password))
                .andExpect(content().string("登入失败"));

        mockMvc.perform(get("/gamedata/verLogin")
                        .param("username", username)
                        .param("password", w_password))
                .andExpect(content().string("登入失败"));
    }

    @Test
    public void register() throws Exception{
        // 用户名存在
        mockMvc.perform(get("/gamedata/register")
                        .param("username", username)
                        .param("password", password)
                        .param("phone", phone)
                        .param("email", email))
                .andExpect(content().string("注册失败"));
        // 错误的手机格式
        mockMvc.perform(get("/gamedata/register")
                        .param("username", username3)
                        .param("password", password)
                        .param("phone", w_phone1)
                        .param("email", email))
                .andExpect(content().string("注册失败"));
        mockMvc.perform(get("/gamedata/register")
                        .param("username", username3)
                        .param("password", password)
                        .param("phone", w_phone2)
                        .param("email", email))
                .andExpect(content().string("注册失败"));
        // 错误的邮箱格式
        mockMvc.perform(get("/gamedata/register")
                        .param("username", username3)
                        .param("password", password)
                        .param("phone", phone)
                        .param("email", w_email1))
                .andExpect(content().string("注册失败"));
        mockMvc.perform(get("/gamedata/register")
                        .param("username", username3)
                        .param("password", password)
                        .param("phone", phone)
                        .param("email", w_email2))
                .andExpect(content().string("注册失败"));
        // 成功注册
        mockMvc.perform(get("/gamedata/register")
                        .param("username", username3)
                        .param("password", password)
                        .param("phone", phone)
                        .param("email", email))
                .andExpect(content().string("注册成功"));
    }
}