package com.example.test;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    private Button Computer;
    private Button Information;
    private Button Electronics;
    private Button Electical;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Computer = findViewById(R.id.buttonCS);
        Information = findViewById(R.id.buttonIS);
        Electronics = findViewById(R.id.buttonEC);
        Electical = findViewById(R.id.buttonEE);

        Computer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent1 = new Intent(MainActivity.this,Main2Activity.class);
                startActivity(intent1);
            }

    });
    Information.setOnClickListener(new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Intent intent2 = new Intent(MainActivity.this,Main2Activity.class);
            startActivity(intent2);
        }
    }
    );
        Electronics.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent3 = new Intent(MainActivity.this,Main3Activity.class);
                startActivity(intent3);
            }
        });
        Electical.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent4 = new Intent(MainActivity.this,Main5Activity.class);
                startActivity(intent4);
            }
        });
}}
