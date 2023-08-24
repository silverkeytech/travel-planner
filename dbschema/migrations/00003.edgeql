CREATE MIGRATION m1kz7dy533f56k7tekjep6auqzp5jf7q2aiijdi6g3mvotgxpwcejq
    ONTO m1zcu2ksawv3qht2z6ee4h55wdou2tcmfxymeihl7637znxs72i4ga
{
  CREATE TYPE default::ItineraryDetails {
      CREATE PROPERTY days_programs: array<tuple<day_number: std::int16, sections: array<tuple<title: std::str, description: std::str>>>>;
      CREATE PROPERTY number_of_days: std::int16;
  };
  ALTER TYPE default::Accomodation {
      CREATE PROPERTY last_update: std::datetime;
  };
  ALTER TYPE default::Activity {
      CREATE PROPERTY last_update: std::datetime;
  };
  ALTER TYPE default::Reservation {
      CREATE LINK itinerary_details: default::ItineraryDetails;
      CREATE PROPERTY request_date: std::datetime;
  };
  CREATE SCALAR TYPE default::ReservationStatus EXTENDING enum<Pending, InProgress, Confirmed>;
  ALTER TYPE default::Reservation {
      CREATE PROPERTY status: default::ReservationStatus;
  };
  ALTER TYPE default::Place_to_visit {
      CREATE PROPERTY last_update: std::datetime;
  };
  ALTER TYPE default::ProgramDetails RENAME TO default::ActivityProgramDetails;
};
