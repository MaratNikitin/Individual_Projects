/*
Day 6 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022.
Author: Marat Nikitin.
This app allows viewing a list of travel agents from the 'travelexperts' database
    and updating their data.
This is the controller class where most of the magic happens.
*/

package marat.day6homeexercise;

import java.net.URL;
import java.sql.*;
import java.util.Optional;
import java.util.ResourceBundle;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.event.EventType;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

public class AgentController {

    @FXML // ResourceBundle that was given to the FXMLLoader
    private ResourceBundle resources;

    @FXML // URL location of the FXML file that was given to the FXMLLoader
    private URL location;

    @FXML // fx:id="btnEdit"
    private Button btnEdit; // Value injected by FXMLLoader

    @FXML // fx:id="btnSave"
    private Button btnSave; // Value injected by FXMLLoader

    @FXML // fx:id="cboAgentID"
    private ComboBox<Integer> cboAgentID; // Value injected by FXMLLoader

    @FXML
    private Label lblSelectAgentID;

    @FXML // fx:id="lblAgencyID"
    private Label lblAgencyID; // Value injected by FXMLLoader

    @FXML // fx:id="lblAgentID"
    private Label lblAgentID; // Value injected by FXMLLoader

    @FXML // fx:id="lblBusPhone"
    private Label lblBusPhone; // Value injected by FXMLLoader

    @FXML // fx:id="lblEmail"
    private Label lblEmail; // Value injected by FXMLLoader

    @FXML // fx:id="lblFirstName"
    private Label lblFirstName; // Value injected by FXMLLoader

    @FXML // fx:id="lblLastName"
    private Label lblLastName; // Value injected by FXMLLoader

    @FXML // fx:id="lblMiddleInitial"
    private Label lblMiddleInitial; // Value injected by FXMLLoader

    @FXML // fx:id="lblPosition"
    private Label lblPosition; // Value injected by FXMLLoader

    @FXML // fx:id="lblUserFeedback"
    private Label lblUserFeedback; // Value injected by FXMLLoader

    @FXML // fx:id="mainWindow"
    private AnchorPane mainWindow; // Value injected by FXMLLoader

    @FXML // fx:id="txtAgencyID"
    private TextField txtAgencyID; // Value injected by FXMLLoader

    @FXML // fx:id="txtAgentID"
    private TextField txtAgentID; // Value injected by FXMLLoader

    @FXML // fx:id="txtBusPhone"
    private TextField txtBusPhone; // Value injected by FXMLLoader

    @FXML // fx:id="txtEmail"
    private TextField txtEmail; // Value injected by FXMLLoader

    @FXML // fx:id="txtFirstName"
    private TextField txtFirstName; // Value injected by FXMLLoader

    @FXML // fx:id="txtLastName"
    private TextField txtLastName; // Value injected by FXMLLoader

    @FXML // fx:id="txtMiddleInitial"
    private TextField txtMiddleInitial; // Value injected by FXMLLoader

    @FXML // fx:id="txtPosition"
    private TextField txtPosition; // Value injected by FXMLLoader

    // this list will hold Agent IDs for the ComboBox:
    ObservableList<Integer> comboBoxOptions = FXCollections.observableArrayList();

    // creating accessible variable for holding the selected Agent ID value:
    private Integer selectedAgentID;

    @FXML // This method is called by the FXMLLoader when initialization is complete
    void initialize() {
        assert btnEdit != null : "fx:id=\"btnEdit\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert btnSave != null : "fx:id=\"btnSave\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert cboAgentID != null : "fx:id=\"cboAgentID\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblAgencyID != null : "fx:id=\"lblAgencyID\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblAgentID != null : "fx:id=\"lblAgentID\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblBusPhone != null : "fx:id=\"lblBusPhone\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblEmail != null : "fx:id=\"lblEmail\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblFirstName != null : "fx:id=\"lblFirstName\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblLastName != null : "fx:id=\"lblLastName\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblMiddleInitial != null : "fx:id=\"lblMiddleInitial\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblPosition != null : "fx:id=\"lblPosition\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert lblUserFeedback != null : "fx:id=\"lblUserFeedback\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert mainWindow != null : "fx:id=\"mainWindow\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert txtAgencyID != null : "fx:id=\"txtAgencyID\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert txtAgentID != null : "fx:id=\"txtAgentID\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert txtBusPhone != null : "fx:id=\"txtBusPhone\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert txtEmail != null : "fx:id=\"txtEmail\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert txtFirstName != null : "fx:id=\"txtFirstName\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert txtLastName != null : "fx:id=\"txtLastName\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert txtMiddleInitial != null : "fx:id=\"txtMiddleInitial\" was not injected: check your FXML file 'agent-view.fxml'.";
        assert txtPosition != null : "fx:id=\"txtPosition\" was not injected: check your FXML file 'agent-view.fxml'.";

        //connecting to the DB and getting a list with ComboBox options:
        fillComboBoxOptions();

        // filling the combobox with options:
        cboAgentID.getItems().addAll(comboBoxOptions);

        // event handler for selecting AgentID from a combobox:
        cboAgentID.setOnAction(event -> {
            selectedAgentID = cboAgentID.getSelectionModel().getSelectedItem();
            displaySelectedAgentInfo(); // most of the code for the event is hidden in this method
            btnEdit.setDisable(false); // enabling the Edit button
            lblUserFeedback.setText(""); // hiding the label
        });

        btnEdit.setOnMouseClicked(new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {

                // disabling the 'Edit' and enabling 'Save' buttons:
                btnSave.setDisable(false);
                btnEdit.setDisable(true);

                // making text fields editable (all except AgentID):
                txtFirstName.setEditable(true);
                txtMiddleInitial.setEditable(true);
                txtLastName.setEditable(true);
                txtBusPhone.setEditable(true);
                txtEmail.setEditable(true);
                txtPosition.setEditable(true);
                txtAgencyID.setEditable(true);

                // fields are open for editing, giving feedback to a user:
                lblUserFeedback.setText("Feel free to make changes and then save them!");
            } // end of handle() method
        }); // end of 'btnEdit.setOnMouseClicked' event handler

        // when the 'Save' button is clicked:
        btnSave.setOnMouseClicked(new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {

                // disabling editing of text fields:
                txtFirstName.setEditable(false);
                txtMiddleInitial.setEditable(false);
                txtLastName.setEditable(false);
                txtBusPhone.setEditable(false);
                txtEmail.setEditable(false);
                txtPosition.setEditable(false);
                txtAgencyID.setEditable(false);

                // preparing for connecting to the 'travelexperts' DB:
                String user = "marat";
                String password = "marat";
                String url = "jdbc:mysql://localhost:3306/travelexperts";

                // user-side validation of user input data:
                Validation v = new Validation();
                String errorMessage = "";
                errorMessage += v.isPresent(txtFirstName.getText(), "First Name");
                errorMessage += v.isPresent(txtLastName.getText(), "Last Name");
                errorMessage += v.isPresent(txtBusPhone.getText(), "Bus Phone");
                errorMessage += v.isPresent(txtEmail.getText(), "E-mail");
                errorMessage += v.isPositiveInteger(txtAgencyID.getText(), "Agency ID");
                errorMessage += v.isNotTooLong(txtFirstName.getText(), "First Name", 20);
                errorMessage += v.isNotTooLong(txtMiddleInitial.getText(), "Middle Initial", 5);
                errorMessage += v.isNotTooLong(txtLastName.getText(), "Last Name", 20);
                errorMessage += v.isNotTooLong(txtBusPhone.getText(), "Bus Phone", 20);
                errorMessage += v.isNotTooLong(txtEmail.getText(), "E-mail", 50);
                errorMessage += v.isNotTooLong(txtPosition.getText(), "Position", 20);

                if (errorMessage.isEmpty()) // true if all input data validation passed successfully
                {
                    // disabling the 'Save' button
                    btnSave.setDisable(true);

                    // connecting to the DB and doing the 'Update' operation:
                    try {
                        // getting DB connection:
                        Connection conn = DriverManager.getConnection(url, user, password);

                        // setting the UPDATE SQL query:
                        String sql = "UPDATE `agents` SET `AgtFirstName`=?,`AgtMiddleInitial`=?," +
                                "`AgtLastName`=?,`AgtBusPhone`=?,`AgtEmail`=?,`AgtPosition`=?,`AgencyId`=? WHERE AgentId=?";

                        // defining each '?' value in the previous SQL query following the order:
                        PreparedStatement stmt = conn.prepareStatement(sql);
                        stmt.setString(1, txtFirstName.getText()); // the first '?'
                        stmt.setString(2, txtMiddleInitial.getText()); // the second '?'
                        stmt.setString(3, txtLastName.getText());
                        stmt.setString(4, txtBusPhone.getText());
                        stmt.setString(5, txtEmail.getText());
                        stmt.setString(6, txtPosition.getText());
                        stmt.setInt(7, Integer.parseInt(txtAgencyID.getText()));
                        stmt.setInt(8, Integer.parseInt(txtAgentID.getText()));
                        int numRows = stmt.executeUpdate(); // executing the Update SQL query
                        if (numRows == 0) // it means that the update has failed
                        {
                            System.out.println("Update failed"); // a friendly warning to a user
                        }
                        else // it means that update in the DB was successful
                        {
                            // a user gets an alert with feedback:
                            Alert alert = new Alert(Alert.AlertType.INFORMATION);
                            alert.setTitle("SUCCESS!");
                            alert.setHeaderText("Mission Accomplished!");
                            alert.setContentText("Success! Changes are made in the database. Please press " +
                                    "'Ok' and select an Agent ID");
                            Optional<ButtonType> result = alert.showAndWait();

                            // clearing the values already saved in the DB
                            txtAgentID.clear();
                            txtFirstName.clear();
                            txtMiddleInitial.clear();
                            txtLastName.clear();
                            txtBusPhone.clear();
                            txtEmail.clear();
                            txtPosition.clear();
                            txtAgencyID.clear();
                            cboAgentID.getSelectionModel().clearSelection(); // selection is cancelled
                            btnEdit.setDisable(true); // disabling the 'Edit' button
                        } // end of else
                    } catch (SQLException e) {
                        lblUserFeedback.setText("Update failed! Check DB connection & try again."); // a label in the form says the same
                        lblUserFeedback.setStyle("-fx-text-fill: #FF0000"); // failure message is in red color
                        btnSave.setDisable(false);
                        e.printStackTrace();
                    } // end of catch
                } // end of 'validation passed' true part of the if statement
                else // it means that validation failed at least once
                {
                    // enabling the 'Edit' and disabling the 'Save' button:
                    btnEdit.setDisable(false);
                    btnSave.setDisable(true);

                    // giving appropriate feedback to a user:
                    Alert alert = new Alert(Alert.AlertType.ERROR);
                    alert.setTitle("ERROR!");
                    alert.setHeaderText("Invalid Input Data");
                    alert.setContentText(errorMessage);
                    alert.showAndWait();
                }


            } // end of the handle() method
        }); // end of the 'btnSave.setOnMouseClicked' event handler

    } // end of the initialize() method

    // this method populates the ComboBox with AgentId options:
    private void fillComboBoxOptions() {
        // username and password for connecting to the travelexperts DB:
        String userName = "marat";
        String password = "marat"; // Safety first! :)
        //connecting to the DB and generating a list of ComboBox options:
        try {
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/travelexperts", userName, password);
            Statement stmt = conn.createStatement();
            ResultSet rs = stmt.executeQuery("select AgentId from agents order by AgentId");
            // generating a list of AgentIDs by looping through each line returned by the query:
            while (rs.next()){
                comboBoxOptions.add(rs.getInt("AgentId"));
            }
            conn.close(); // mission accomplished - DB connection is closed
        } catch (SQLException e) {
            e.printStackTrace();
        } // end of catch
    } // end of fillComboBoxOptions() method

    // this method populates text fields with the selected agent's data:
    private void displaySelectedAgentInfo() {
        // username and password for connecting to the travelexperts DB:
        String userName = "marat";
        String password = "marat"; // Safety first! :)
        // connecting to the DB, retrieving data of the selected agent and displaying it:
        try {
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/travelexperts", userName, password);
            Statement stmt = conn.createStatement();
            ResultSet rs = stmt.executeQuery("select * from agents where AgentId = " + selectedAgentID);
            while (rs.next()){
                // populating text fields with data of the single selected agent:
                txtAgentID.setText(selectedAgentID.toString());
                txtFirstName.setText(rs.getString("AgtFirstName"));
                txtMiddleInitial.setText(rs.getString("AgtMiddleInitial"));
                txtLastName.setText(rs.getString("AgtLastName"));
                txtBusPhone.setText(rs.getString("AgtBusPhone"));
                txtEmail.setText(rs.getString("AgtEmail"));
                txtPosition.setText(rs.getString("AgtPosition"));
                txtAgencyID.setText(rs.getString("AgencyId"));
            }
            conn.close(); // mission accomplished, time to close the DB connection
        } catch (SQLException e) {
            e.printStackTrace();
        } //end of catch
    } // end of displaySelectedAgentInfo() method
} // end of AgentController class
