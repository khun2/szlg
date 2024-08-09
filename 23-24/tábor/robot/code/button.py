from machine import Pin, reset #type: ignore
from config import config
	 
bt = Pin(config['reset_button']['pin'], Pin.IN, Pin.PULL_UP)
bt.irq(lambda _: reset(), hard=True)