import http from 'k6/http';
import { check, sleep } from 'k6';

// Load profile: ramp up to 20 VUs, hold briefly, then ramp down
export const options = {
    stages: [
        { duration: '10s', target: 10 }, // ramp to 10 users
        { duration: '10s', target: 20 }, // ramp to 20 users
        { duration: '10s', target: 0 },  // ramp down
    ],
    thresholds: {
        // 95% of requests must be faster than 500ms
        http_req_duration: ['p(95)<500'],
        // Less than 1% of all requests may fail
        http_req_failed: ['rate<0.01'],
    },
};

export default function () {
    const res = http.get('http://localhost:5000/');

    check(res, {
        'status is 200': (r) => r.status === 200,
    });

    sleep(1);
}

