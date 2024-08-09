from RGB_sensor import RgbSensor 
from machine import Pin, I2C #type: ignore
from config import config
from button import bt
from hbridge import HBridge
from time import sleep_ms

sensor = RgbSensor(
    I2C(
        config['rgb_sensor']['i2c_chan'],
        scl=Pin(config['rgb_sensor']['scl']),
        sda=Pin(config['rgb_sensor']['sda'])
    ),

    led_pin=Pin(config['rgb_sensor']['led'], Pin.OUT)
        if config['rgb_sensor']['led'] else None,
    interrupt_pin=Pin(config['rgb_sensor']['int'], Pin.OUT)
        if config['rgb_sensor']['int'] else None,

    integration_time=config['rgb_sensor']['integration_time'],
    gain=config['rgb_sensor']['gain']
)

while True:
  print(sensor.get_data())
