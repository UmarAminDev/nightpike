from agent.parser import parse_line

SAMPLE_LINES = [
    "2026-11-14T03:14:22-06:00 nightpike-vm sshd[2841]: Failed password for root from 45.83.64.12 port 51022 ssh2",
    "2026-11-14T03:14:25-06:00 nightpike-vm sshd[2843]: Failed password for invalid user admin from 45.83.64.12 port 51040 ssh2",
    "2026-11-14T09:02:11-06:00 nightpike-vm sshd[3110]: Accepted publickey for umar from 24.72.10.5 port 60212 ssh2",
]


def main() -> None:
    for line in SAMPLE_LINES:
        print(parse_line(line))