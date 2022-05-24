/*
Days 10 & 12 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022.
Author: Marat Nikitin.
This app allows viewing a list of travel agents from the 'travelexperts' database
    and updating their data.
This class helps with the 'activity_about.fxml' file activated from the 'About' menu option.
*/

package marat.day10_12;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class AboutActivity extends AppCompatActivity {

    // defining the 'Back' button
    Button btnBack3;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_about);

        // finding the 'Back' button
        btnBack3 = findViewById(R.id.btnBack3);

        // when the 'Back' button' is clicked, a user is redirected to the Main page:
        btnBack3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(), MainActivity.class);
                startActivity(intent);
            }
        });
    }
}