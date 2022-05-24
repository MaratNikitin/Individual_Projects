/*
Days 10 & 12 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022.
Author: Marat Nikitin.
This app allows viewing a list of travel agents from the 'travelexperts' database
    and updating their data.
This is the class responsible for the "activity_agents_details" window.
*/

package marat.day10_12;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class AgentDetailsActivity extends AppCompatActivity {

    // defining objects at a class level:
    EditText etAgentID, etFirstName, etMiddleInitial, etLastName,
            etBusPhone, etEmail, etPosition, etAgencyID;
    Button btnBack, btnSave, btnDelete;
    DataSource dataSource;
    TextView lblAgentID, tvAddEditDelete;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_agent_details);

        // finding all the numerous defined objects of the form:
        etAgentID = findViewById(R.id.etAgentID);
        etFirstName = findViewById(R.id.etFirstName);
        etMiddleInitial = findViewById(R.id.etMiddleInitial);
        etLastName = findViewById(R.id.etLastName);
        etBusPhone = findViewById(R.id.etBusPhone);
        etEmail = findViewById(R.id.etEmail);
        etPosition = findViewById(R.id.etPosition);
        etAgencyID = findViewById(R.id.etAgencyID);
        btnBack = findViewById(R.id.btnBack);
        btnSave = findViewById(R.id.btnSave);
        btnDelete = findViewById(R.id.btnDelete);
        dataSource = new DataSource(this);
        lblAgentID = findViewById(R.id.lblAgentID);
        tvAddEditDelete = findViewById(R.id.tvAddEditDelete);

        // retrieving the selected Agent class instance:
        Intent intent = getIntent();
        Agent agent = (Agent) intent.getSerializableExtra("agent");
        String mode = intent.getStringExtra("mode");

        if (mode.equals("edit"))
        {
            // filling up text views with appropriate information:
            etAgentID.setText(agent.getAgentId() + "");
            etFirstName.setText(agent.getAgtFirstName());
            etMiddleInitial.setText(agent.getAgtMiddleInitial());
            etLastName.setText(agent.getAgtLastName());
            etBusPhone.setText(agent.getAgtBusPhone());
            etEmail.setText(agent.getAgtEmail());
            etPosition.setText(agent.getAgtPosition());
            etAgencyID.setText(agent.getAgencyId() + "");
            lblAgentID.setText("Agent ID: ");
        }
        else // it mean it's the 'Add' mode:
        {
            btnDelete.setVisibility(View.INVISIBLE); // hiding the "Delete" button
            etAgentID.setVisibility(View.INVISIBLE); // hiding the text field for AgentID (it's auto-incremented)
            lblAgentID.setText(""); // hiding the 'Agent ID' label by setting an empty string as its content
            tvAddEditDelete.setText("Please enter all requested data \nand press the 'Save' button:");
            // giving appropriate instructions to a user
        }

        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(), MainActivity.class);
                startActivity(intent); // opening the main window ('activity_main.fxml')
            }
        });

        // when 'Save' button is clicked:
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (mode.equals("edit")) // true if it's the 'edit' mode (happens when an agent's name is selected)
                {
                    // updated data is passed to the updateAgent() method:
                    int updateResult = dataSource.updateAgent(new Agent(
                            Integer.parseInt(etAgentID.getText().toString()), // Agent ID
                            etFirstName.getText().toString(), // First Name
                            etMiddleInitial.getText().toString(), // Middle Initial
                            etLastName.getText().toString(), // Last Name
                            etBusPhone.getText().toString(),
                            etEmail.getText().toString(),
                            etPosition.getText().toString(),
                            Integer.parseInt(etAgencyID.getText().toString())
                            ));
                    // giving feedback to a user in a toast:
                    if (updateResult == 1) // i.e. one row was affected in the DB
                    {
                        Toast.makeText(getApplicationContext(), "Update operation was successfull!",
                                Toast.LENGTH_LONG).show();
                    }
                    else // operation failed
                    {
                        Toast.makeText(getApplicationContext(), "Update operation failed!",
                                Toast.LENGTH_LONG).show();
                    }
                    AgentDetailsActivity.this.finish();
                }
                else // it's the 'add' mode
                {
                    int insertResult = dataSource.insertAgent(new Agent(
                            0, // because Agent ID is an auto-incremented primary key
                            etFirstName.getText().toString(), // First Name
                            etMiddleInitial.getText().toString(), // Middle Initial
                            etLastName.getText().toString(), // Last Name
                            etBusPhone.getText().toString(),
                            etEmail.getText().toString(),
                            etPosition.getText().toString(),
                            Integer.parseInt(etAgencyID.getText().toString())
                    ));
                    // giving feedback to a user in a toast:
                    if (insertResult >= 1) // i.e. one row was affected in the DB (as db.insert returns a new Agent's ID)
                    {
                        Toast.makeText(getApplicationContext(), "Insert new agent operation was successfull!",
                                Toast.LENGTH_LONG).show();
                    }
                    else // operation failed
                    {
                        Toast.makeText(getApplicationContext(), "Insert a new agent operation failed!",
                                Toast.LENGTH_LONG).show();
                    }
                    AgentDetailsActivity.this.finish();
                }
            }
        });

        // when 'Delete' button is clicked:
        btnDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // Asking for confirmation in a dialog window before executing the Delete operation:
                AlertDialog.Builder builder = new AlertDialog.Builder(AgentDetailsActivity.this);
                builder.setCancelable(true);
                builder.setTitle("CONFIRM DELETE"); // meaningful instructions to a user
                builder.setMessage("Please confirm the delete operation"); // meaningful instructions to a user
                builder.setPositiveButton("Confirm", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                if (mode.equals("edit")) // extra check of the mode
                                {
                                    int deleteResult = dataSource.deleteAgent(Integer.parseInt(etAgentID.getText().toString()));
                                    // giving feedback to a user in a toast:
                                    if (deleteResult == 1) // i.e. one row was affected in the DB
                                    {
                                        Toast.makeText(getApplicationContext(), "Delete operation was successfull!",
                                                Toast.LENGTH_LONG).show();
                                    }
                                    else
                                    {
                                        Toast.makeText(getApplicationContext(), "Delete operation failed!",
                                                Toast.LENGTH_LONG).show();
                                    }
                                    AgentDetailsActivity.this.finish();
                                }
                            }
                        });
                builder.setNegativeButton(android.R.string.cancel, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // some friendly feedback to a user would not hurt:
                        Toast.makeText(getApplicationContext(), "Delete operation was cancelled.",
                                Toast.LENGTH_LONG).show();
                    }
                });
                AlertDialog dialog = builder.create();
                dialog.show(); // displaying the dialog window asking for Delete confirmation
            }
        });

    } // end of onCreate method

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

} // end of AgentDetailsActivity class