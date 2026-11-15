#Send an event to API
import httpx

API_URL = "http://localhost:5196/api/events"


def send_event(event: dict) -> bool:
    try:
        response = httpx.post(API_URL, json=event, timeout=5.0)
    except httpx.RequestError as error:
        print(f"Could not reach API: {error}")
        return False

    if response.status_code == 201:
        return True

    print(f"API rejected event ({response.status_code}): {response.text}")
    return False