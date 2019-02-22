package com.example.smartload;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Toast;

public class Menu extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);
        Toast toast= Toast.makeText(this, "sUCCESS", Toast.LENGTH_SHORT);
        toast.show();
    }
}
