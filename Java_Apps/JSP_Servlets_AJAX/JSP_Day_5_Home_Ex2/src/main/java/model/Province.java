/*
JSP/Servlets - Day 5 Individual Home Assignment
CPRG-220 - Open Source Web Applications, OOSD program,
SAIT, April 2022
Author: Marat Nikitin
This is the REST application side allowing sharing contents of the 'Agents', 'Provinces',
    and 'States' tables of the 'travelexperts' database. It runs well on Tomcat9.
This class was created by Java Persistence Architecture (JPA).
*/

package model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "provinces")
public class Province {
    @Id
    @Column(name = "ProvinceCode", nullable = false, length = 2)
    private String id;

    @Column(name = "ProvinceName", nullable = false, length = 50)
    private String provinceName;

    @Column(name = "Country", nullable = false, length = 50)
    private String country;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getProvinceName() {
        return provinceName;
    }

    public void setProvinceName(String provinceName) {
        this.provinceName = provinceName;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

}