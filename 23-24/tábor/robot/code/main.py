from machine import Pin #type: ignore
from hbridge import HBridge
from ultra_sensor import UltraSensor
from RGB_sensor import RgbSensor
from debug import dprint, define_controls, recv_changes
from networking import setup_wifi, setup_dbg
from dbg_magic import DbgVal
from config import config
from time import sleep_ms
from button import bt

ultra =  UltraSensor(
    Pin(config['ultra_sensor']['trig'], Pin.OUT),
    Pin(config['ultra_sensor']['echo'], Pin.IN)
)

hb = HBridge(
    Pin(config['h_bridge']['pwm_l'],  Pin.OUT),
    Pin(config['h_bridge']['pwm_r'],  Pin.OUT),
    Pin(config['h_bridge']['1A'], Pin.OUT),
    Pin(config['h_bridge']['2A'], Pin.OUT),
    Pin(config['h_bridge']['3A'], Pin.OUT),
    Pin(config['h_bridge']['4A'], Pin.OUT),

    config['h_bridge']['freq']
)




tav = 0.3
P = 5
I = 0
D = 0

integr = 0
prev_err = 0

dt = 0.020

'''hb.drive(0, 0.5)

sleep_ms(5000)

hb.drive(0, 0)'''


while True:
    dist = ultra.measure_sync()

    if dist is None:
        continue
    print(dist)

    err = tav - dist
    integr = integr + err * dt
    der = (err - prev_err) / dt

    o = -(P * err + I * integr + D * der)

    hb.drive(o,o)

    sleep_ms(int(dt * 1000))


# setup_wifi()
# setup_dbg()

# ctrls ={
#     'test': DbgVal('asd')
# }

# define_controls(ctrls)

# while True:
#     recv_changes(ctrls)
#     dprint(ctrls)

# print('asd')

#from RGB_sensor import RgbSensor 
#from machine import Pin, I2C #type: ignore
#from config import config
#from button import bt
#from hbridge import HBridge
#from time import sleep_ms
#
#sensor = RgbSensor(
#    I2C(
#        config['rgb_sensor']['i2c_chan'],
#        scl=Pin(config['rgb_sensor']['scl']),
#        sda=Pin(config['rgb_sensor']['sda'])
#    ),
#
#    led_pin=Pin(config['rgb_sensor']['led'], Pin.OUT)
#        if config['rgb_sensor']['led'] else None,
#    interrupt_pin=Pin(config['rgb_sensor']['int'], Pin.OUT)
#        if config['rgb_sensor']['int'] else None,
#
#    integration_time=config['rgb_sensor']['integration_time'],
#    gain=config['rgb_sensor']['gain']
#)
#
#while True:
#  print(sensor.get_data())

