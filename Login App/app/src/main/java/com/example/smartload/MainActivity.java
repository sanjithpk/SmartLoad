package com.example.smartload;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    EditText User;
    EditText Password;
    Button Login;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        User = findViewById(R.id.etUser);
        Password = findViewById(R.id.etPass);
        Login = findViewById(R.id.Login);
    }

    //        Login.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                validate(User.getText().toString(),Password.getText().toString());
//            }
//        });
//private void validate(String UserName, String Password){
//        if ((UserName == "Admin")&& (Password=="1234")){
//            Intent intent = new Intent(MainActivity.this, SecondActivity.class);
//            startActivity(intent);
//        }else{
//            counter--;
//            if (counter == 0){
//                Login.setEnabled(false);
//            }
//        }
//}
    public void OnLogin(View view) {
        String username=User.getText().toString();
        String password=Password.getText().toString();
        String type ="login";
        BackgroundWorker backgroundWorker = new BackgroundWorker(this);
        backgroundWorker.execute(type,username,password);
    }
}
