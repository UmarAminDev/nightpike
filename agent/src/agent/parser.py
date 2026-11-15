import re

FAILED_LOGIN = re.compile(
    r"^(?P<timestamp>\S+) (?P<host>\S+) sshd\[\d+\]: "
    r"Failed password for (?P<invalid>invalid user )?(?P<username>\S+) "
    r"from (?P<ip>\S+) port \d+"
   
)

def parse_line(line: str) -> dict | None:
    match = FAILED_LOGIN.search(line)
    if match is None: # early return 
        return None

    return { #build and return event as a dictionary
        "occurredAt": match.group("timestamp"),
        "eventType": "ssh_failed_login",
        "username": match.group("username"),
        "sourceIp": match.group("ip"),
        "invalidUser": match.group("invalid") is not None,
        "host": match.group("host"),
        "rawLine": line.strip(),
    }