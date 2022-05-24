module marat.day6homeexercise {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.sql;


    opens marat.day6homeexercise to javafx.fxml;
    exports marat.day6homeexercise;
}