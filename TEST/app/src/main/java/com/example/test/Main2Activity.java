package com.example.test;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.util.ArrayList;

public class Main2Activity extends AppCompatActivity {
    private Button submit;

    final ArrayList<String> list = new ArrayList<String>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);
        final Button submit = findViewById(R.id.button);
        final EditText editText = findViewById(R.id.editText2);
        TextView textArea = findViewById(R.id.textView2);


        submit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                list.add(editText.getText().toString());
            }
        });

        for(int y=0; y<=list.size()-1; y++){
            textArea.setText(list.get(y));   //prints all strings in the array
        }
    }


}
