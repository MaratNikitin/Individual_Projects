package model;

import javax.persistence.*;

@Entity
@Table(name = "agencies")
public class Agency {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "AgencyId", nullable = false)
    private Integer id;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

//TODO [JPA Buddy] generate columns from DB
}