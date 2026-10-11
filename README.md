# NightPike

NightPike is a security monitoring platform that watches a Linux server for attacks, such as brute-force logins and scanning, and displays them on a dashboard.

## Goal behind the project

Servers connected to the internet start getting attacked by bots as soon as they're live: password guessing, port scans, and probes for weak spots. Security teams use monitoring tools to track this activity so analysts can focus on what matters. This project is a small version of those tools, built to learn how attacks appear in real logs and how detection works.

## Architecture

- **Agent (Python):** runs on the server, reads SSH and web-server logs, and sends suspicious events to the API.
- **API (C# / ASP.NET Core):** receives events, stores them, and runs detection rules to raise alerts.
- **Database (PostgreSQL):** stores events, alerts, servers, and users.
- **Dashboard (React):** lets an analyst log in, view alerts, and mark them as reviewed.

## Planned detections

- **SSH brute force:** multiple failed logins from one IP within a short time window
- **Web scanning:** one IP requesting many nonexistent pages
- **Suspicious success:** a successful login from an IP after repeated failures

## Tech stack

C#, ASP.NET Core, PostgreSQL, Python, React, TypeScript, Docker, GitHub Actions

## Status

- 🚧 In development
- First milestone: the agent sends failed SSH login events to the API