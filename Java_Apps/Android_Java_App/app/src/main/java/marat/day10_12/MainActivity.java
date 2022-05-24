/*
Days 10 & 12 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022.
Author: Marat Nikitin.
This app allows viewing a list of travel agents from the 'travelexperts' database
    and updating their data.
This is the MainActivity class responsible for the "activity_main" window.
*/

package marat.day10_12;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;

public class MainActivity extends AppCompatActivity {

    // defining objects at a class level:
    DataSource dataSource;
    ListView lvAgents;
    ArrayAdapter<Agent> adapter;
    Button btnAdd;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        dataSource = new DataSource(this);
        // finding the objects:
        lvAgents = findViewById(R.id.lvAgents);
        btnAdd = findViewById(R.id.btnAdd);

        loadData();

        // this part below is commented out as it is code for the Day 10 Home Assignment:

        /*// creating adapter and implementing it in ListView implementing custom display styles:
        adapter = new ArrayAdapter<>(this, R.layout.listview_styles);
        lvAgents.setAdapter(adapter);

        // creating hardcoded Agent instances:
        Agent agent1 = new Agent(1, "John", "D.", "Smith",
                "403-966-9999","jsmith@texperts.com", "Junior Agent", 1);
        Agent agent2 = new Agent(2, "James", "B.", "Brown",
                "403-555-7777","jbrown@texperts.com", "Senior Agent", 2);
        Agent agent3 = new Agent(3, "Jessica", "R.", "Phillips",
                "403-970-8888","jphillips@texperts.com", "Senior Agent", 1);

        // adding agents to the adapter:
        adapter.add(agent1);
        adapter.add(agent2);
        adapter.add(agent3);*/

        // when an item is clicked in the ListView:
        lvAgents.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                Intent intent = new Intent(getApplicationContext(), AgentDetailsActivity.class);
                //Agent agent = adapter.getItem(i);
                intent.putExtra("agent", (Agent)lvAgents.getAdapter().getItem(i));
                intent.putExtra("mode", "edit");
                startActivity(intent);
            }
        });

        // when the 'Add' button is clicked on the main page
        btnAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(), AgentDetailsActivity.class);
                intent.putExtra("mode", "add");
                startActivity(intent);
            }
        });

    } // end of onCreate()

    // making sure that menu bar is properly displayed:
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    // menu options (the only one that is there):
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId())
        {
            case R.id.miAbout:
                startActivity(new Intent(this, AboutActivity.class));
                return true;
            default:
                ;
        }
        return super.onOptionsItemSelected(item);
    }

    // method for loading data into the ListView:
    private void loadData() {
        ArrayAdapter<Agent> adapter =
                new ArrayAdapter<>(this, R.layout.listview_styles, // using custom styling for the ListView
                        dataSource.getAllAgents());
        lvAgents.setAdapter(adapter); // data loads into the ListView
    }

    // when the MainActivity is started:
    @Override
    protected void onStart() {
        super.onStart();
        loadData(); // loading data into the ListView
    }

    // when the MainActivity is resumed:
    @Override
    protected void onResume() {
        super.onResume();
        loadData(); // loading data into the ListView
    }
}