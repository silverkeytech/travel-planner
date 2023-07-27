CREATE MIGRATION m16z4gxsq4domz24ot6ubwnobyprhvvyelxgjakpgxjd3jl54ijnxq
    ONTO initial
{
  CREATE TYPE default::Accomodation {
      CREATE PROPERTY hotel_name: std::str;
      CREATE PROPERTY preferences: std::str;
      CREATE PROPERTY price: std::int16;
      CREATE PROPERTY room_type: std::str;
  };
  CREATE TYPE default::Activity {
      CREATE PROPERTY activity_duration: std::duration;
      CREATE PROPERTY name: std::str;
      CREATE PROPERTY number_of_persons: std::int16;
      CREATE PROPERTY price: std::int16;
  };
  CREATE TYPE default::Place_to_visit {
      CREATE PROPERTY name: std::str;
      CREATE PROPERTY number_of_persons: std::int16;
      CREATE PROPERTY place_duration: std::duration;
      CREATE PROPERTY price: std::int16;
  };
  CREATE TYPE default::Transportation {
      CREATE PROPERTY car_model: std::str;
      CREATE PROPERTY dropoff_loaction: std::str;
      CREATE PROPERTY pickup_location: std::str;
      CREATE PROPERTY price: std::int16;
      CREATE PROPERTY seat_number: std::int16;
  };
  CREATE TYPE default::User {
      CREATE PROPERTY email: std::str;
      CREATE PROPERTY first_name: std::str;
      CREATE PROPERTY languages: array<std::str>;
      CREATE PROPERTY last_name: std::str;
      CREATE PROPERTY mobile_phone: std::str;
      CREATE PROPERTY nationality: std::str;
  };
  CREATE TYPE default::CostumeTrip {
      CREATE LINK accomodation: default::Accomodation;
      CREATE MULTI LINK activities: default::Activity;
      CREATE MULTI LINK places_to_visit: default::Place_to_visit;
      CREATE LINK transportation: default::Transportation;
      CREATE LINK user: default::User;
      CREATE PROPERTY adults: std::int16;
      CREATE PROPERTY children: std::int16;
      CREATE PROPERTY end_date: std::datetime;
      CREATE PROPERTY notes: std::str;
      CREATE PROPERTY pick_up_loaction: std::str;
      CREATE PROPERTY price: std::int16;
      CREATE PROPERTY start_date: std::datetime;
      CREATE PROPERTY tour_guid: std::str;
  };
  CREATE TYPE default::BudgetTrip {
      CREATE LINK user: default::User;
      CREATE PROPERTY adults: std::int16;
      CREATE PROPERTY budget_amount: std::int16;
      CREATE PROPERTY children: std::int16;
      CREATE PROPERTY end_date: std::datetime;
      CREATE PROPERTY start_date: std::datetime;
  };
};
