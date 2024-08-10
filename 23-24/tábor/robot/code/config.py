from json import load

with open('config.json') as f:
    config = load(f)

with open('network_config.json') as f:
    config['network']['creds'] = load(f)