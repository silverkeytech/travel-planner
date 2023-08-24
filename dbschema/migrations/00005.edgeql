CREATE MIGRATION m1jbyrxle3em2kbvmor6bw2ehhbwcmdu5senz5aeruupqji5tbyroa
    ONTO m1f63cro3asnwdelcawfqkuxjmhsji4xb5ivfghiqtiygczt3nk4ba
{
  ALTER TYPE default::Activity {
      DROP LINK program_detail;
  };
  ALTER TYPE default::Activity {
      CREATE MULTI LINK programs: default::ActivityProgramDetails;
  };
  ALTER TYPE default::Activity {
      CREATE PROPERTY programs_Highlights: std::str;
  };
  ALTER TYPE default::ActivityProgramDetails {
      DROP LINK prices;
  };
  ALTER TYPE default::ActivityProgramDetails {
      CREATE PROPERTY name: std::str;
  };
  ALTER TYPE default::ActivityProgramDetails {
      CREATE PROPERTY price: std::float32;
  };
  ALTER TYPE default::ActivityProgramDetails {
      ALTER PROPERTY program_Highlights {
          RENAME TO details;
      };
  };
  ALTER TYPE default::ActivityProgramDetails {
      CREATE PROPERTY time_to_spent: std::duration;
  };
  ALTER TYPE default::ActivityProgramPrice {
      DROP PROPERTY details;
  };
  ALTER TYPE default::ActivityProgramPrice {
      DROP PROPERTY name;
  };
  ALTER TYPE default::ActivityProgramPrice {
      DROP PROPERTY price;
  };
  ALTER TYPE default::ActivityProgramPrice RENAME TO default::AdminActivity;
  CREATE SCALAR TYPE default::AdminRole EXTENDING enum<admin>;
  CREATE TYPE default::Admin {
      CREATE MULTI LINK admin_activities: default::AdminActivity;
      CREATE PROPERTY admin_role: default::AdminRole;
      CREATE PROPERTY email: std::str;
      CREATE PROPERTY first_name: std::str;
      CREATE PROPERTY join_date: std::datetime;
      CREATE PROPERTY last_name: std::str;
      CREATE PROPERTY password: std::str;
      CREATE PROPERTY username: std::str;
  };
  ALTER TYPE default::AdminActivity {
      CREATE LINK admin: default::Admin;
      CREATE LINK accommodation: default::Accomodation;
      CREATE LINK activity: default::Activity;
      CREATE LINK place: default::PlaceToVisit;
      CREATE LINK reservation: default::Reservation;
  };
  CREATE SCALAR TYPE default::AdminActivityAction EXTENDING enum<Added, Updated, Removed>;
  ALTER TYPE default::AdminActivity {
      CREATE PROPERTY admin_activity_action: default::AdminActivityAction;
      CREATE PROPERTY date: std::datetime;
  };
  ALTER TYPE default::PlaceToVisit {
      CREATE PROPERTY time_to_spent: std::duration;
  };
};
