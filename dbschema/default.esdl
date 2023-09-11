module default {
    scalar type TransportationType extending enum<PrivateSedan, PrivateMinibus, PublicBus>;
    scalar type RoomType extending enum<SingleRoom, DoubleRoom, TripleRoom>;
    scalar type AccommodationMode extending enum<Friends, Family, Solo>;
    
    # To be extending for more tags
    scalar type AccommodationFacilities extending enum<Wifi, RoomService, FreeParking, DisabledGuests, Beachfront>;
    scalar type ReservationStatus extending enum<Pending, InProgress, Confirmed>;
    scalar type Languages extending enum<Arabic, English>;
    # Should we assign different roles for admins? aka one responsible of reservations only, 
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
        tour_guide_languages: array<Languages>;
        start_date: datetime;
        end_date: datetime;
        transportation: Transportation;
        # rooms are a multiple of tuples with room and their required count
        multi reserved_rooms: ReservedRoom;
        multi programs: Program;
        multi places_to_visit: PlaceToVisit;
        status: ReservationStatus;
        request_date: datetime;
        itinerary_details: ItineraryDetails;
    }
    type FamilyReservation extending Reservation {
        number_of_adults: int16;
        number_of_children: int16;
    }
    type FriendsReservation extending Reservation {
        number_of_adults: int16;
    }
    type SoloReservation extending Reservation {
        join_group: bool;
    }
    type ReservedRoom {
        multi room: Room;
        count: int16;
        check_in: datetime;
        check_out: datetime;
    }
    # Used to generate the tour guide languages to the form
    type TourGuide {
        first_name: str;
        last_name: str;
        mobile_phone: str;
        languages_spoken: array<Languages>;
        available: bool;
        # In case the tour guide is available, start and end date will be null
        start_date: datetime;
        end_date: datetime;
    }
    type Transportation {
        transportation_type: TransportationType;
        max_capacity: int16;
        price: float32;
    }
    type Accommodation {
        hotel_name: str;
        accommodation_modes: array<AccommodationMode>;
        location: str;
        latitude: float32; # Used to display location on map
        longitude: float32;
        short_description: str;
        long_description: str;
        profile_picture_path: str;
        number_of_stars: int16;
        accommodation_facilities: array<AccommodationFacilities>;
        multi reviews: AccommodationReview;
        images_path: array<str>;
        last_update: datetime;
        multi rooms: Room{
            on target delete allow;
        };
    }
    type Room {
        room_type: RoomType;
        capacity: int16;
        price_per_night: float32;
        description: str;
        available_rooms_count: int16;
    }
    type AccommodationReview {
        guest_name: str;
        nationality: str;
        rate: float32;
        comment: str;
        date: datetime;
    }
    type PlaceToVisit {
        name: str;
        image_path: str;
        description: str;
        price: float32;
        time_to_spend: duration;
        last_update: datetime;
    }
    type Program {
        name: str;
        image_path: str;
        description: str;
        program_Highlights: array<str>;
        # For the single program, it can have multiple activities(at least one activity)
        multi activities: ActivityDetails;
        last_update: datetime;
    }
    type ActivityDetails {
        name: str;
        details: str;
        time_to_spend: duration;
        price: float32;
    }
    type ItineraryDetails {
        number_of_days: int16;
        # For every reservation, you have an array of days,
        # and for every day you have a day_number and array of sections
        # consisting of title and description 
        days_programs: array<tuple<day_number: int16, sections: array<tuple<title: str, description: str>>>>;
        assigned_tour_guide: TourGuide;
    }
    type Admin {
        first_name: str;
        last_name: str;
        email: str;
        username: str;
        password: str;
        multi admin_activities: AdminActivity;
        join_date: datetime;      
    }
    # Ex:   admin x confirmed a reservation number 12345678 on 8/24/2023
    #       admin x edited accommodation Taghaghien Island Resort 8/20/2023
    # For every admin activity you have only one field of these 4(reservation, place, activity, accommodation, admin)
    type AdminActivity {
        admin_activity_action: AdminActivityAction;
        admin: Admin;
        reservation: Reservation;
        place: PlaceToVisit;
        program: Program;
        accommodation: Accommodation;
        date: datetime;
    }
}
