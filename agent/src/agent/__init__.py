from agent.parser import parse_line
from agent.sender import send_event

LOG_FILE = "sample-logs/auth.log"


def main() -> None:
    sent = 0
    with open(LOG_FILE) as file:
        for line in file:
            event = parse_line(line)
            if event is None:
                continue
            if send_event(event):
                sent += 1
    print(f"Sent {sent} event(s) to the API.")