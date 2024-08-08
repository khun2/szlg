from machine import Pin #type: ignore
import ultra_sensor

sensor = ultra_sensor.UltraSensor(Pin(20, Pin.OUT), Pin(19, Pin.IN))

while True:
  print(sensor.measure_sync())