#include <dht.h>

dht DHT;
dht DHT1;
#define DHT22_PIN 5
#define DHT221_PIN 6
void setup() {
  // put your setup code here, to run once:
 Serial.begin(2000000);
}

void loop() {
 

  
    int chk = DHT.read22(DHT22_PIN);
 int chk1 = DHT1.read22(DHT221_PIN);

   
  // put your main code here, to run repeatedly:
double nem,sicaklik;
  nem=  DHT.humidity;
 sicaklik=DHT.temperature;

 double nem1,sicaklik1;
  nem1=  DHT1.humidity;
 sicaklik1=DHT1.temperature;
 
 Serial.print(sicaklik,1);
   Serial.print("*");
 //Serial.print(" \n");
     Serial.print(nem,1);
  // Serial.print("*");
Serial.print("*");
//Serial.print(" \n");

Serial.print(sicaklik1,1);
   Serial.print("*");
 //Serial.print(" \n");
     Serial.print(nem1,1);
  // Serial.print("*");
Serial.print("*");
Serial.print(" \n");
  
  //  Serial.println();
delay(1000);
}
