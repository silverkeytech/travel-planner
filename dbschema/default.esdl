module default {
    # ToDo: Add constraints for fields
    type CostumeTrip {
        start_date: datetime;
        end_date: datetime;
        adults: int16;
        children: int16;
        user: User;
        transportation: Transportation;
        pick_up_loaction: str;
        accomodation: Accomodation;
        multi places_to_visit: Place_to_visit;
        multi activities: Activity;
        tour_guid: str;
        price: int16;
        notes: str;
    }
    type User {
        first_name: str;
        last_name: str;
        email: str;
        mobile_phone: str;
        nationality: str;
        languages: array<str>;
    }
    type Transportation {
        car_model: str;
        seat_number: int16;
        pickup_location: str;
        dropoff_loaction: str;
        price: int16;
    }
    type Accomodation {
        hotel_name: str;
        room_type: str;
        price: int16;
        preferences: str;
    }
    type Place_to_visit {
        name: str;
        place_duration: duration;
        number_of_persons: int16;
        price: int16;
    }
    type Activity {
        name: str;
        activity_duration: duration;
        number_of_persons: int16;
        price: int16;
    }
    type BudgetTrip {
        start_date: datetime;
        end_date: datetime;
        adults: int16;
        children: int16;
        user: User;
        budget_amount: int16;
    }
}
