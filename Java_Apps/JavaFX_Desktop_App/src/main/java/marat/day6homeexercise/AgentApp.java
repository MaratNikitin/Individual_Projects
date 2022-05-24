/*
Day 6 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022.
Author: Marat Nikitin.
This app allows viewing a list of travel agents from the 'travelexperts' database
    and updating their data. The form is responsive.
This is the class where the application launch happens, the rest is handled by the controller class.
*/

package marat.day6homeexercise;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.IOException;

public class AgentApp extends Application {
    @Override
    public void start(Stage stage) throws IOException {
        FXMLLoader fxmlLoader = new FXMLLoader(AgentApp.class.getResource("agent-view.fxml"));
        Scene scene = new Scene(fxmlLoader.load());
        // uploading a .css stylesheet:
        String css = this.getClass().getResource("/css/styles.css").toExternalForm();
        scene.getStylesheets().add(css);
        stage.setTitle("Agents Application"); // setting the form's title
        stage.setScene(scene);
        stage.show();
    }

    // launching the app:
    public static void main(String[] args) {
        launch();
    }
}