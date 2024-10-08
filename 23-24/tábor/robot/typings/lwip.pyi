from typing import Any

SOCK_RAW: int
SOCK_DGRAM: int
SO_REUSEADDR: int
SOCK_STREAM: int
SOL_SOCKET: int
AF_INET6: int
AF_INET: int
IP_DROP_MEMBERSHIP: int
IPPROTO_IP: int
IP_ADD_MEMBERSHIP: int

def reset(*args, **kwargs) -> Any: ...
def print_pcbs(*args, **kwargs) -> Any: ...
def getaddrinfo(*args, **kwargs) -> Any: ...
def callback(*args, **kwargs) -> Any: ...

class socket:
    def recvfrom(self, *args, **kwargs) -> Any: ...
    def recv(self, *args, **kwargs) -> Any: ...
    def makefile(self, *args, **kwargs) -> Any: ...
    def listen(self, *args, **kwargs) -> Any: ...
    def settimeout(self, *args, **kwargs) -> Any: ...
    def sendall(self, *args, **kwargs) -> Any: ...
    def setsockopt(self, *args, **kwargs) -> Any: ...
    def setblocking(self, *args, **kwargs) -> Any: ...
    def sendto(self, *args, **kwargs) -> Any: ...
    def readline(self, *args, **kwargs) -> Any: ...
    def readinto(self, *args, **kwargs) -> Any: ...
    def read(self, *args, **kwargs) -> Any: ...
    def close(self, *args, **kwargs) -> Any: ...
    def connect(self, *args, **kwargs) -> Any: ...
    def send(self, *args, **kwargs) -> Any: ...
    def bind(self, *args, **kwargs) -> Any: ...
    def accept(self, *args, **kwargs) -> Any: ...
    def write(self, *args, **kwargs) -> Any: ...
    def __init__(self, *argv, **kwargs) -> None: ...
