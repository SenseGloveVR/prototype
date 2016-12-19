#include <Servo.h>

Servo myservo;
int data;
int pos = 0;
char myCol[20];

void setup() {
  Serial.begin(9600);
  pinMode (13,  OUTPUT);
  myservo.attach(9);
}

void loop() {

  int lf = 10;
  Serial.readBytesUntil(lf, myCol, 1);

  if (strcmp(myCol, "s") == 0) {
    digitalWrite(13, HIGH);
    for (pos = 0; pos < 180; pos += 1) 
    { // in steps of 1 degree
      myservo.write(pos);              
      delay(1);                       
    }
  }

  if (strcmp(myCol, "f") == 0) {
    digitalWrite(13, LOW);
    for (pos = 180; pos >= 1; pos -= 1)
    {
      myservo.write(pos);              
      delay(15);                       
    }
  }
}
