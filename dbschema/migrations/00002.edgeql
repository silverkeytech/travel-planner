CREATE MIGRATION m1zcu2ksawv3qht2z6ee4h55wdou2tcmfxymeihl7637znxs72i4ga
    ONTO m16z4gxsq4domz24ot6ubwnobyprhvvyelxgjakpgxjd3jl54ijnxq
{
  CREATE SCALAR TYPE default::AccomodationFacilities EXTENDING enum<Wifi, RoomService, FreeParking, DisabledGuests, Beachfront>;
  ALTER TYPE default::Accomodation {
      CREATE PROPERTY accomodation_facilities: array<default::AccomodationFacilities>;
  };
  CREATE SCALAR TYPE default::AccomodationMode EXTENDING enum<Friends, Family, Solo>;
  ALTER TYPE default::Accomodation {
      CREATE PROPERTY accomodation_mode: array<default::AccomodationMode>;
  };
  CREATE TYPE default::Review {
      CREATE PROPERTY comment: std::str;
      CREATE PROPERTY guest_name: std::str;
      CREATE PROPERTY rate: std::float32;
  };
  ALTER TYPE default::Accomodation {
      CREATE MULTI LINK reviews: default::Review;
  };
  ALTER TYPE default::Accomodation {
      CREATE PROPERTY images_path: array<std::str>;
  };
  ALTER TYPE default::Accomodation {
      CREATE PROPERTY latitude: std::float32;
  };
  ALTER TYPE default::Accomodation {
      CREATE PROPERTY longitude: std::float32;
  };
  ALTER TYPE default::Accomodation {
      ALTER PROPERTY preferences {
          RENAME TO location;
      };
  };
  ALTER TYPE default::Accomodation {
      ALTER PROPERTY price {
          RENAME TO number_of_stars;
      };
  };
  ALTER TYPE default::Accomodation {
      CREATE PROPERTY profile_picture_path: std::str;
  };
  ALTER TYPE default::Accomodation {
      ALTER PROPERTY room_type {
          RENAME TO long_description;
      };
  };
  ALTER TYPE default::Accomodation {
      CREATE PROPERTY short_description: std::str;
  };
  ALTER TYPE default::BudgetTrip {
      DROP LINK user;
  };
  ALTER TYPE default::BudgetTrip {
      DROP PROPERTY adults;
  };
  ALTER TYPE default::BudgetTrip {
      DROP PROPERTY budget_amount;
  };
  ALTER TYPE default::BudgetTrip {
      DROP PROPERTY children;
  };
  ALTER TYPE default::BudgetTrip {
      DROP PROPERTY end_date;
  };
  ALTER TYPE default::BudgetTrip {
      DROP PROPERTY start_date;
  };
  ALTER TYPE default::BudgetTrip RENAME TO default::ProgramDetails;
  ALTER TYPE default::Activity {
      CREATE LINK program_detail: default::ProgramDetails;
  };
  ALTER TYPE default::Activity {
      DROP PROPERTY activity_duration;
  };
  ALTER TYPE default::Activity {
      CREATE PROPERTY description: std::str;
  };
  ALTER TYPE default::Activity {
      CREATE PROPERTY image_path: std::str;
  };
  ALTER TYPE default::Activity {
      DROP PROPERTY number_of_persons;
  };
  ALTER TYPE default::Activity {
      DROP PROPERTY price;
  };
  ALTER TYPE default::CostumeTrip {
      DROP LINK accomodation;
  };
  ALTER TYPE default::CostumeTrip {
      DROP LINK activities;
  };
  ALTER TYPE default::CostumeTrip {
      DROP LINK places_to_visit;
  };
  ALTER TYPE default::CostumeTrip {
      DROP LINK transportation;
  };
  ALTER TYPE default::CostumeTrip {
      DROP LINK user;
  };
  ALTER TYPE default::CostumeTrip {
      DROP PROPERTY adults;
  };
  ALTER TYPE default::CostumeTrip {
      DROP PROPERTY children;
  };
  ALTER TYPE default::CostumeTrip {
      DROP PROPERTY end_date;
  };
  ALTER TYPE default::CostumeTrip {
      DROP PROPERTY price;
  };
  ALTER TYPE default::CostumeTrip {
      DROP PROPERTY start_date;
  };
  ALTER TYPE default::CostumeTrip {
      DROP PROPERTY tour_guid;
  };
  ALTER TYPE default::CostumeTrip RENAME TO default::ActivityProgramPrice;
  ALTER TYPE default::ActivityProgramPrice {
      ALTER PROPERTY notes {
          RENAME TO details;
      };
  };
  ALTER TYPE default::ActivityProgramPrice {
      ALTER PROPERTY pick_up_loaction {
          RENAME TO name;
      };
  };
  ALTER TYPE default::ActivityProgramPrice {
      CREATE PROPERTY price: std::float32;
  };
  CREATE SCALAR TYPE default::RoomType EXTENDING enum<SingleRoom, DoubleRoom, TripleRoom>;
  CREATE TYPE default::Room {
      CREATE LINK hotel_name: default::Accomodation;
      CREATE PROPERTY capacity: std::int16;
      CREATE PROPERTY description: std::str;
      CREATE PROPERTY price_per_night: std::float32;
      CREATE PROPERTY room_type: default::RoomType;
  };
  CREATE ABSTRACT TYPE default::Reservation {
      CREATE MULTI LINK activities: default::Activity;
      CREATE MULTI LINK places_to_visit: default::Place_to_visit;
      CREATE MULTI LINK rooms: default::Room;
      CREATE LINK transportation: default::Transportation;
      CREATE PROPERTY check_in: std::datetime;
      CREATE PROPERTY check_out: std::datetime;
      CREATE PROPERTY code: std::str;
      CREATE PROPERTY email: std::str;
      CREATE PROPERTY mobile_phone: std::str;
      CREATE PROPERTY name: std::str;
      CREATE PROPERTY nationalities: array<std::str>;
      CREATE PROPERTY ticket_number: std::str;
      CREATE PROPERTY tour_guide: std::bool;
      CREATE PROPERTY tour_guide_languages: array<std::str>;
  };
  CREATE TYPE default::FamilyReservation EXTENDING default::Reservation {
      CREATE PROPERTY number_of_adults: std::int16;
      CREATE PROPERTY number_of_childs: std::int16;
  };
  CREATE TYPE default::FriendsReservation EXTENDING default::Reservation {
      CREATE PROPERTY number_of_people: std::int16;
  };
  ALTER TYPE default::Place_to_visit {
      CREATE PROPERTY description: std::str;
  };
  ALTER TYPE default::Place_to_visit {
      CREATE PROPERTY image_path: std::str;
  };
  ALTER TYPE default::Place_to_visit {
      DROP PROPERTY number_of_persons;
  };
  ALTER TYPE default::Place_to_visit {
      DROP PROPERTY place_duration;
      ALTER PROPERTY price {
          SET TYPE std::float32;
      };
  };
  ALTER TYPE default::ProgramDetails {
      CREATE MULTI LINK prices: default::ActivityProgramPrice;
      CREATE PROPERTY program_Highlights: std::str;
  };
  CREATE TYPE default::SoloReservation EXTENDING default::Reservation {
      CREATE PROPERTY join_group: std::bool;
  };
  ALTER TYPE default::Transportation {
      CREATE PROPERTY availability: std::bool;
  };
  ALTER TYPE default::Transportation {
      DROP PROPERTY car_model;
  };
  ALTER TYPE default::Transportation {
      DROP PROPERTY dropoff_loaction;
  };
  ALTER TYPE default::Transportation {
      DROP PROPERTY pickup_location;
      ALTER PROPERTY price {
          SET TYPE std::float32;
      };
  };
  ALTER TYPE default::Transportation {
      ALTER PROPERTY seat_number {
          RENAME TO capacity;
      };
  };
  CREATE SCALAR TYPE default::TransportationType EXTENDING enum<PrivateSedan, PrivateMinibus, PublicBus>;
  ALTER TYPE default::Transportation {
      CREATE PROPERTY transportation_type: default::TransportationType;
  };
  ALTER TYPE default::User {
      DROP PROPERTY last_name;
  };
  ALTER TYPE default::User {
      DROP PROPERTY mobile_phone;
  };
  ALTER TYPE default::User {
      DROP PROPERTY nationality;
  };
  ALTER TYPE default::User RENAME TO default::TourGuide;
  ALTER TYPE default::TourGuide {
      CREATE PROPERTY availability: std::bool;
  };
  ALTER TYPE default::TourGuide {
      ALTER PROPERTY email {
          RENAME TO mobile_phone;
      };
  };
  ALTER TYPE default::TourGuide {
      ALTER PROPERTY first_name {
          RENAME TO name;
      };
  };
  ALTER TYPE default::TourGuide {
      ALTER PROPERTY languages {
          RENAME TO languages_spoken;
      };
  };
};
