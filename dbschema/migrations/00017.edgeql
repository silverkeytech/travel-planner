CREATE MIGRATION m1yrq63zmas7qnk6qfycaty3eo3ndxht2ejwbvmib4ee77all5ge2q
    ONTO m1jv6yoppohotfb4nttobmilfsgleexdx47ykouw7ybj2serxd2k5a
{
  ALTER TYPE default::ActivityDetails {
      DROP PROPERTY details;
  };
  ALTER TYPE default::Program {
      ALTER PROPERTY image_path {
          RENAME TO profile_picture_path;
      };
  };
  ALTER TYPE default::Program {
      CREATE PROPERTY images_path: array<std::str>;
  };
  ALTER TYPE default::ReservedRoom {
      ALTER LINK room {
          RESET CARDINALITY USING (SELECT
              .room 
          LIMIT
              1
          );
      };
  };
  ALTER SCALAR TYPE default::AccommodationFacilities EXTENDING enum<OutdoorSwimmingPool, FreeParking, Restaurant, SpaAndWellnessCentre, PetsAllowed, WIFI, RoomService, BeachFront, Breakfast>;
};
