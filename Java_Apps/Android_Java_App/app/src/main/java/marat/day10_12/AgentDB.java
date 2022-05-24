/*
Days 10 & 12 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022.
Author: Marat Nikitin.
This app allows viewing a list of travel agents from the 'travelexperts' database
    and updating their data.
This class provides methods to create a DB with Agents table and populate it with rows of data.
This Agents DB table is identical to the Agents table of "TravelExpertsSqlLite.db".
As an alternative, the complete "TravelExpertsSqlLite.db" database can be installed in the apps
folder, contents of the onCreate() and onUpgrade methods should be commented out, and the app
will work the same.
*/

package marat.day10_12;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class AgentDB extends SQLiteOpenHelper {
    private static final String NAME = "TravelExpertsSqlLite.db"; // name of the DB
    private static final int VERSION = 1; // something needs to be here


    public AgentDB(@Nullable Context context) {
        super(context, NAME, null, VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {

        // dropping Agents if it exists:
        db.execSQL("drop table if exists Agents");

        // creating an empty Agents table:
        String sql = "CREATE TABLE Agents("
                + "AgentId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                + " AgtFirstName TEXT,"
                + " AgtMiddleInitial TEXT,"
                + " AgtLastName	TEXT,"
                + " AgtBusPhone	TEXT,"
                + " AgtEmail TEXT,"
                + " AgtPosition TEXT,"
                + " AgencyId INTEGER)";
        db.execSQL(sql);

        // populating the DB table with values:
        sql = "insert into Agents values(null, 'Janet', '', 'Delton', '(403) 210-7801', " +
                "'janet.delton@travelexperts.com', 'Senior Agent', 1)";
        db.execSQL(sql);

        sql = "insert into Agents values(null, 'Judy', '', 'Lisle', '(403) 210-7802', " +
                "'judy.lisle@travelexperts.com', 'Intermediate Agent', 1)";
        db.execSQL(sql);

        sql = "insert into Agents values(null, 'Dennis', 'C.', 'Reynolds', '(403) 210-7843', " +
                "'dennis.reynolds@travelexperts.com', 'Junior Agent', 1)";
        db.execSQL(sql);

        sql = "insert into Agents values(null, 'John', '', 'Coville', '(403) 210-7823', " +
                "'john.coville@travelexperts.com', 'Intermediate Agent', 1)";
        db.execSQL(sql);

        sql = "insert into Agents values(null, 'Janice', 'W.', 'Dahl', '(403) 210-7865', " +
                "'janice.dahl@travelexperts.com', 'Senior Agent', 1)";
        db.execSQL(sql);

        sql = "insert into Agents values(null, 'Bruce', 'J.', 'Dixon', '(403) 210-7867', " +
                "'bruce.dixon@travelexperts.com', 'Intermediate Agent', 2)";
        db.execSQL(sql);

        sql = "insert into Agents values(null, 'Beverly', 'S.', 'Jones', '(403) 210-7812', " +
                "'beverly.jones@travelexperts.com', 'Intermediate Agent', 2)";
        db.execSQL(sql);

        sql = "insert into Agents values(null, 'Jane', '', 'Merrill', '(403) 210-7868', " +
                "'jane.merrill@travelexperts.com', 'Senior Agent', 2)";
        db.execSQL(sql);

        sql = "insert into Agents values(null, 'Brian', 'S.', 'Peterson', '(403) 210-7833', " +
                "'brian.peterson@travelexperts.com', 'Junior Agent', 2)";
        db.execSQL(sql);

    }

    // on upgrading the app the DB values reset:
    @Override
    public void onUpgrade(SQLiteDatabase db, int i, int i1) {
        db.execSQL("drop table if exists Agents"); // dropping the previous Agents table
        onCreate(db); // creating the DB anew
    }

}
