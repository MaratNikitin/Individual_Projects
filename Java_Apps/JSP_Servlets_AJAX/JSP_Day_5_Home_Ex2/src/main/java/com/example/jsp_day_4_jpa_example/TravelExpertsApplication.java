/*
JSP/Servlets - Day 5 Individual Home Assignment
CPRG-220 - Open Source Web Applications, OOSD program,
SAIT, April 2022
Author: Marat Nikitin
This is the REST application side allowing sharing contents of the 'Agents', 'Provinces',
    and 'States' tables of the 'travelexperts' database. It runs well on Tomcat9.
*/

package com.example.jsp_day_4_jpa_example;

import javax.ws.rs.ApplicationPath;
import javax.ws.rs.core.Application;

@ApplicationPath("/api")
public class TravelExpertsApplication extends Application {

}