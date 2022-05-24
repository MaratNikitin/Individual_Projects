/*
Days 10 & 12 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022.
Author: Marat Nikitin.
This app allows viewing a list of travel agents from the 'travelexperts' database
    and updating their data.
This class contains methods for CRUD operations.
*/

package marat.day10_12;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import java.util.ArrayList;

public class DataSource {
    private Context context;
    private SQLiteDatabase db;
    private AgentDB helper;

    public DataSource(Context context) {
        this.context = context;
        helper = new AgentDB(context);
        db = helper.getWritableDatabase();
    }

    // method for displaying agents in the Listview:
    public ArrayList<Agent> getAllAgents() {
        ArrayList<Agent> list = new ArrayList<>();
        String [] columns = {"AgentId", "AgtFirstName", "AgtMiddleInitial", "AgtLastName",
                "AgtBusPhone", "AgtEmail", "AgtPosition", "AgencyId" };
        Cursor cursor = db.query("Agents", columns, null,
                null, null, null, null);
        while (cursor.moveToNext())
        {
            list.add(new Agent(cursor.getInt(0), cursor.getString(1), cursor.getString(2), cursor.getString(3),
                    cursor.getString(4), cursor.getString(5), cursor.getString(6), cursor.getInt(7)));
        }
        return list;
    }

    // method for updating an Agent's data in the database:
    public int updateAgent(Agent agent)
    {
        ContentValues cv = new ContentValues();
        cv.put("AgtFirstName", agent.getAgtFirstName()); // extra line for each column of the DB table
        cv.put("AgtMiddleInitial", agent.getAgtMiddleInitial()); // extra line for each column of the DB table
        cv.put("AgtLastName", agent.getAgtLastName()); // extra line for each column of the DB table
        cv.put("AgtBusPhone", agent.getAgtBusPhone()); // extra line for each column of the DB table
        cv.put("AgtEmail", agent.getAgtEmail()); // extra line for each column of the DB table
        cv.put("AgtPosition", agent.getAgtPosition()); // extra line for each column of the DB table
        cv.put("AgencyId", agent.getAgencyId()); // extra line for each column of the DB table
        String [] args = {agent.getAgentId()+""};
        String where = "AgentId=?";
        return db.update("Agents", cv, where, args);
    }

    // method for inserting a new Agent's data in the database:
    public int insertAgent(Agent agent)
    {
        ContentValues cv = new ContentValues();
        cv.put("AgtFirstName", agent.getAgtFirstName()); // extra line for each column of the DB table
        cv.put("AgtMiddleInitial", agent.getAgtMiddleInitial()); // extra line for each column of the DB table
        cv.put("AgtLastName", agent.getAgtLastName()); // extra line for each column of the DB table
        cv.put("AgtBusPhone", agent.getAgtBusPhone()); // extra line for each column of the DB table
        cv.put("AgtEmail", agent.getAgtEmail()); // extra line for each column of the DB table
        cv.put("AgtPosition", agent.getAgtPosition()); // extra line for each column of the DB table
        cv.put("AgencyId", agent.getAgencyId()); // extra line for each column of the DB table
        return (int) db.insert("Agents", null, cv);
    }

    // method for deleting a selected Agent's data from the database:
    public int deleteAgent (int agentId)
    {
        String where = "AgentId=?";
        String [] args = {agentId + ""};
        return db.delete("Agents", where, args);
    }

} // end of 'DataSource' class
