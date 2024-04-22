package com.gameproject.gamebackend.entity;

import lombok.Data;
import lombok.Getter;

import java.io.Serializable;
import java.util.Date;

@Data
public class GameData implements Serializable {

    private String username;
    private int record;
    private java.sql.Date date;
    private String dateString;
    private int eleft;

}
