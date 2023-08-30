CREATE MIGRATION m12tp6wnyb4hxmgr6omfpcuwahfgvjreqlkc2zljn4rw4fcl5p5oja
    ONTO m1jbyrxle3em2kbvmor6bw2ehhbwcmdu5senz5aeruupqji5tbyroa
{
  CREATE SCALAR TYPE default::Languages EXTENDING enum<Arabic, English>;
  ALTER TYPE default::TourGuide {
      ALTER PROPERTY languages_spoken {
          SET TYPE array<default::Languages>;
      };
  };
  ALTER TYPE default::Reservation {
      ALTER PROPERTY tour_guide_languages {
          SET TYPE array<default::Languages>;
      };
  };
  ALTER TYPE default::Accomodation {
      CREATE MULTI LINK rooms: default::Room;
  };
  ALTER TYPE default::Accomodation {
      ALTER PROPERTY accomodation_mode {
          RENAME TO accomodation_modes;
      };
  };
  ALTER TYPE default::ActivityProgramDetails {
      ALTER PROPERTY time_to_spent {
          RENAME TO time_to_spend;
      };
  };
  ALTER TYPE default::AdminActivity {
      DROP LINK admin;
  };
  CREATE TYPE default::ReservedRoom {
      CREATE MULTI LINK room: default::Room;
      CREATE PROPERTY count: std::int16;
  };
  ALTER TYPE default::Reservation {
      CREATE MULTI LINK reserved_rooms: default::ReservedRoom;
  };
  ALTER TYPE default::Reservation {
      DROP LINK rooms;
  };
  ALTER TYPE default::FamilyReservation {
      ALTER PROPERTY number_of_childs {
          RENAME TO number_of_children;
      };
  };
  ALTER TYPE default::FriendsReservation {
      ALTER PROPERTY number_of_people {
          RENAME TO number_of_adults;
      };
  };
  ALTER TYPE default::ItineraryDetails {
      CREATE LINK assigned_tour_guide: default::TourGuide;
  };
  ALTER TYPE default::PlaceToVisit {
      ALTER PROPERTY time_to_spent {
          RENAME TO time_to_spend;
      };
  };
  ALTER TYPE default::Review RENAME TO default::AccomodationReview;
  ALTER TYPE default::Room {
      DROP LINK hotel_name;
  };
  ALTER TYPE default::Room {
      CREATE PROPERTY available_rooms_count: std::int16;
  };
  ALTER TYPE default::TourGuide {
      ALTER PROPERTY availability {
          RENAME TO available;
      };
  };
  ALTER TYPE default::TourGuide {
      CREATE PROPERTY end_date: std::datetime;
  };
  ALTER TYPE default::TourGuide {
      CREATE PROPERTY last_name: std::str;
  };
  ALTER TYPE default::TourGuide {
      ALTER PROPERTY name {
          RENAME TO first_name;
      };
  };
  ALTER TYPE default::TourGuide {
      CREATE PROPERTY start_date: std::datetime;
  };
  ALTER TYPE default::Transportation {
      DROP PROPERTY availability;
  };
  ALTER TYPE default::Transportation {
      ALTER PROPERTY capacity {
          RENAME TO max_capacity;
      };
  };
};
