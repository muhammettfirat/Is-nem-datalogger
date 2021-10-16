#include<Servo.h>
Servo motor;
Servo motor1;
int aci;
 
void setup() {
 motor.attach(3);
 motor1.attach(4);
}
 
void loop() {
 
for(aci=0;aci<=180;aci+=20){
motor.write(aci);
motor1.write(aci);
delay(100);
}
for(aci=180;aci>=0;aci-=20){
motor.write(aci);
motor1.write(aci);
delay(100);
}
 
}
