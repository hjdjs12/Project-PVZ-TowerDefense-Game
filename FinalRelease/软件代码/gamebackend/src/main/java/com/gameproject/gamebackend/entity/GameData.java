package com.gameproject.gamebackend.entity;

import lombok.Data;
import lombok.Getter;

import java.io.Serializable;
import java.util.Date;

@Data
public class GameData implements Serializable {

    private String username;
    private String password;
    private int record;
    //private java.sql.Date date;
    private String date;
    private int eleft;
    // 新加入的邮箱地址和手机号码
    private String email;
    private String phone;
}
