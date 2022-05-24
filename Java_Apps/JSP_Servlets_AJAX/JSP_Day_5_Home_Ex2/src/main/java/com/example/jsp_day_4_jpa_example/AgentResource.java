/*
JSP/Servlets - Day 5 Individual Home Assignment
CPRG-220 - Open Source Web Applications, OOSD program,
SAIT, April 2022
Author: Marat Nikitin
This is the REST application side allowing sharing contents of the 'Agents', 'Provinces',
    and 'States' tables of the 'travelexperts' database. It runs well on Tomcat9.
Routing happens here. Old working demo was taken as basis to circumvent numerous errors.
*/

package com.example.jsp_day_4_jpa_example;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import model.Agent;
import model.Province;
import model.State;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;
import java.lang.reflect.Type;
import java.util.List;

@Path("/table")
public class AgentResource {

    // constructor:
    public AgentResource()
    {
        try
        {
            // ensuring that Maria DB drivers are found:
            Class.forName("org.mariadb.jdbc.Driver");
        }
        catch (ClassNotFoundException e)
        {
            e.printStackTrace();
        }
    }

    // Get a list of all Canadian Provinces as GSON objects:
    @Path("/provinces") // URL: http://localhost:8080/api/table/provinces
    @GET // Accessible by GET Method
    @Produces(MediaType.APPLICATION_JSON) // JSON/GSON objects are returned here
    public String getProvinces() {
        String response = ""; // introducing and initiating the variable to be returned
        // referencing a persistence unit from the persistence.xml file:
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("provinces");
        EntityManager em = emf.createEntityManager(); // introducing EntityManager instance - opening DB connection
        Query query = em.createQuery("SELECT p FROM Province p"); //selecting all provinces
        List<Province> provincesList = query.getResultList(); // creating a list for Province class objects
        Type type = new TypeToken<List<Province>>(){}.getType(); // setting a Type of JSON objects
        Gson gson = new Gson(); // introducing JSON/GSON object
        response = gson.toJson(provincesList, type); // saving JSON/GSON list to be returned
        em.close(); // mission accomplished, connection closed
        return response; // returning a JSON/GSON list of Canadian provinces
    } // end of getProvinces

    // Get a list of all US States as JSON/GSON objects:
    @Path("/states") // URL: http://localhost:8080/api/table/states
    @GET // Accessible by GET Method
    @Produces(MediaType.APPLICATION_JSON) // JSON/GSON objects are returned here
    public String getStates() {
        String response = ""; // introducing and initiating the variable to be returned
        // referencing a persistence unit from the persistence.xml file:
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("states");
        EntityManager em = emf.createEntityManager(); // introducing EntityManager instance - opening DB connection
        Query query = em.createQuery("SELECT s FROM State s"); //selecting all states
        List<State> statesList = query.getResultList(); // creating a list for State class objects
        Type type = new TypeToken<List<State>>(){}.getType(); // setting a Type of JSON objects
        Gson gson = new Gson(); // introducing JSON/GSON object
        response = gson.toJson(statesList, type); // saving JSON/GSON list to be returned
        em.close(); // mission accomplished, connection closed
        return response; // returning a JSON/GSON list of US states
    } // end of getStates

    // Get a list of all Agents as JSON/GSON objects:
    @Path("agents") // URL: http://localhost:8080/api/table/agents
    @GET // Accessible by GET Method
    @Produces(MediaType.APPLICATION_JSON) // JSON objects are returned here
    public String getAgents()
    {
        String response = ""; // introducing and initiating the variable to be returned
        // referencing a persistence unit of the persistence.xml file:
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("agents");
        EntityManager em = emf.createEntityManager(); // introducing EntityManager instance - opening DB connection
        Query query = em.createQuery("SELECT a FROM Agent a"); //select all agents
        List<Agent> agentList = query.getResultList(); // creating a list for Agent class objects
        Type type = new TypeToken<List<Agent>>(){}.getType(); // setting a Type of JSON objects
        Gson gson = new Gson(); // introducing JSON/GSON object
        response = gson.toJson(agentList, type); // saving JSON/GSON list to be returned
        em.close(); // mission accomplished, connection closed
        return response; // returning a JSON/GSON list of agents
    }



// ***********************************************************************************************************************************
    // All the code below is the legacy of our JPA Day 4 Class Demo (it's left there for future reference).

    /**
     * Get selected agent
     * @param agentId
     * @return
     */
    @Path("/getagent/{AgentId}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public String getAgent(@PathParam("AgentId") int agentId)
    {
        String response = "";
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("default");
        EntityManager em = emf.createEntityManager();
        Agent agent = em.find(Agent.class, agentId);

        Gson gson = new Gson();
        response = gson.toJson(agent);
        em.close();
        return response;
    }



    /**
     * Update agent information
     * @param JSONString
     * @return
     */
    @Path("/postagent")
    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Consumes({MediaType.APPLICATION_JSON})
    public String postAgent(String JSONString)
    {
        String response = "";
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("default");
        EntityManager em = emf.createEntityManager();

        Gson gson = new Gson();
        Agent agent = gson.fromJson(JSONString, Agent.class);
        em.getTransaction().begin();
        Agent mergedAgent = em.merge(agent);
        if(mergedAgent != null)
        {
            em.getTransaction().commit();
            em.close();
            response = "{'message', 'Agent was updated successfully'}";
        }
        else
        {
            em.getTransaction().rollback();
            em.close();
            response = "{'message', 'Failed to update agent'}";
        }
        return response;
    }

    /**
     * Add agent to table
     * @param JSONString
     * @return
     */
    @Path("/addagent")
    @PUT
    @Produces(MediaType.APPLICATION_JSON)
    @Consumes({MediaType.APPLICATION_JSON})
    public String addAgent(String JSONString)
    {
        String response = "";
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("default");
        EntityManager em = emf.createEntityManager();

        Gson gson = new Gson();
        Agent agent = gson.fromJson(JSONString, Agent.class);
        em.getTransaction().begin();
        em.persist(agent);
        if(em.contains(agent))
        {
            em.getTransaction().commit();
            em.close();
            response = "{'message', 'Agent was inserted successfully'}";
        }
        else
        {
            em.getTransaction().rollback();
            em.close();
            response = "{'message', 'Failed to insert agent'}";
        }
        return response;
    }

    /**
     * Get selected agent
     * @param agentId
     * @return
     */
    @Path("/deleteagent/{AgentId}")
    @DELETE
    @Produces(MediaType.APPLICATION_JSON)
    public String deleteAgent(@PathParam("AgentId") int agentId)
    {
        String response = "";
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("default");
        EntityManager em = emf.createEntityManager();

        Agent agent = em.find(Agent.class, agentId);

        em.getTransaction().begin();
        em.remove(agent);

        if(!em.contains(agent))
        {
            em.getTransaction().commit();
            em.close();
            response = "{'message', 'Agent was deleted successfully'}";
        }
        else
        {
            em.getTransaction().rollback();
            em.close();
            response = "{'message', 'Failed to delete agent'}";
        }
        return response;
    }
}