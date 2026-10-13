CREATE TABLE IF NOT EXISTS events (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    occurred_at timestamptz NOT NULL,
    received_at timestamptz NOT NULL DEFAULT now(),
    event_type text NOT NULL,
    username text,
    source_ip inet NOT NULL,
    invalid_user boolean NOT NULL DEFAULT false,
    host text NOT NULL,
    raw_line text NOT NULL
);

CREATE TABLE IF NOT EXISTS alerts (
    id bigint PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    attack_type text NOT NULL,
    source_ip inet NOT NULL,
    severity text NOT NULL CHECK (severity IN ('low', 'medium', 'high')),
    status text NOT NULL CHECK (status IN ('open', 'acknowledged', 'resolved')) DEFAULT 'open',
    first_seen timestamptz NOT NULL,
    last_seen timestamptz NOT NULL,
    event_count integer NOT NULL,
    created_at timestamptz NOT NULL DEFAULT now()
);