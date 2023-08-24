module default {
    scalar type TransportationType extending enum<PrivateSedan, PrivateMinibus, PublicBus>;
    scalar type RoomType extending enum<SingleRoom, DoubleRoom, TripleRoom>;
    scalar type AccomodationMode extending enum<Friends, Family, Solo>;
    
    # To be extending for more tags
    scalar type AccomodationFacilities extending enum<Wifi, RoomService, FreeParking, DisabledGuests, Beachfront>;
    scalar type ReservationStatus extending enum<Pending, InProgress, Confirmed>;
    
    # Should we assign different roles for admins? aka one responsible of reservations only, 
    # one responsible of adjusting accommodations and places, and so on ???
    scalar type AdminRole extending enum<admin>;
    scalar type AdminActivityAction extending enum<Added, Updated, Removed>;

    # ToDo: Add constraints for fields
    abstract type Reservation {
        ticket_number: str;
        code: str;
        name: str;
        email: str;
        mobile_phone: str;
        nationalities: array<str>;
        tour_guide: bool;
        tour_guide_languages: array<str>;
        check_in: datetime;
        check_out: datetime;
        transportation: Transportation;
        multi rooms: Room;
        multi activities: Activity;
        multi places_to_visit: PlaceToVisit;
        status: ReservationStatus;
        request_date: datetime;
        itinerary_details: ItineraryDetails;
    }
    type FamilyReservation extending Reservation {
        number_of_adults: int16;
        number_of_childs: int16;
    }
    type FriendsReservation extending Reservation {
        number_of_people: int16;
    }
    type SoloReservation extending Reservation {
        join_group: bool;
    }
    # Used to generate the tour guide languages to the form
    type TourGuide {
        name: str;
        mobile_phone: str;
        languages_spoken: array<str>;
        availability: bool;
    }
    type Transportation {
        transportation_type: TransportationType;
        capacity: int16;
        price: float32;
        availability: bool;
    }
    type Accomodation {
        hotel_name: str;
        accomodation_mode: array<AccomodationMode>;
        location: str;
        latitude: float32; # Used to display location on map
        longitude: float32;
        short_description: str;
        long_description: str;
        profile_picture_path: str;
        number_of_stars: int16;
        accomodation_facilities: array<AccomodationFacilities>;
        multi reviews: Review;
        images_path: array<str>;
        last_update: datetime;
    }
    type Room {
        room_type: RoomType;
        capacity: int16;
        price_per_night: float32;
        hotel_name: Accomodation;
        description: str;
    }
    type Review {
        guest_name: str;
        rate: float32;
        comment: str;
    }
    type PlaceToVisit {
        name: str;
        image_path: str;
        description: str;
        price: float32;
        time_to_spent: duration;
        last_update: datetime;
    }
    type Activity {
        name: str;
        image_path: str;
        description: str;
        programs_Highlights: str;
        # For the single activity, it can have multiple programs(at least one program)
        multi programs: ActivityProgramDetails;
        last_update: datetime;
    }
    type ActivityProgramDetails {
        name: str;
        details: str;
        time_to_spent: duration;
        price: float32;
    }
    type ItineraryDetails {
        number_of_days: int16;
        # For every reservation, you have an array of days,
        # and for every day you have a day_number and array of sections
        # consisting of title and description 
        days_programs: array<tuple<day_number: int16, sections: array<tuple<title: str, description: str>>>>
    }
    type Admin {
        first_name: str;
        last_name: str;
        email: str;
        username: str;
        password: str;
        admin_role: AdminRole;
        multi admin_activities: AdminActivity;
        join_date: datetime;      
    }
    # Ex:   admin x confirmed a reservation number 12345678 on 8/24/2023
    #       admin x edited accommodation Taghaghien Island Resort 8/20/2023
    # For every admin activity you have only one field of these 4(reservation, place, activity, accommodation, admin)
    type AdminActivity {
        admin_activity_action: AdminActivityAction;
        reservation: Reservation;
        place: PlaceToVisit;
        activity: Activity;
        accommodation: Accomodation;
        admin: Admin;
        date: datetime;
    }
}
