# Schedule

As a scheduling tool it should be reasonably assumed that the product will be used with other business tool f.e. to generate pay information and for analytics. Product should support features for aggregating information about crew hours. Most airlines separate paid hours into duty hours and all other hours spent away from base, the latter paid at a lower rate, with only active roles on flights counting as duty hours.

# Flights

A flight is characterized by an origin and destination airport, and a flight number. The flight number is unique for a given origin, destination, and schedule; but not aircraft or aircraft type. The same flight will usually be scheduled several times over a week.
A flight will only be allowed to depart while it meets the following requirements. The flight must have sufficient crew who are qualified on that aircraft. All crew used on the flight must have sufficient duty hours remaining to complete the flight (see Crew section below). If a crewmember does not have enough duty hours left, they can be replaced by another crewmember that does.
Since the number of required crew is based in part on the number of passengers, flights must keep track of the number of passengers. The specific information about passengers is beyond the scope of the product. 
It may be necessary sometimes to fly extra crew to another airport to staff a future flight, in which case that crew must be placed on a flight that has extra seats available. Crew not performing crew duties must occupy passenger seats specifically, an extra flight attendant station cannot be used for this purpose.

# Crews

This is a matter of flight planning rather than crew scheduling, so it should not be handled by this product. However, it is useful to know for generating example flight plans.
Crewmembers should be characterized by a base or closest airport. Crewmembers should return to their base routinely depending on their schedule availability. Crews should also have a measurement of seniority measured in years. Crews with higher seniority have priority in making scheduling decisions: will be sent to their base first, and will be used to replace other crews last. 
Most airlines limit the number of duty hours a crewmember can perform in a given time period, after which they must rest for a predetermined amount of time. Typically, only time on the ground is counted as rest, and only if there are no upcoming flights for the rest of the day. These duty and rest rules should be configurable.
Flights are typically arranged such that crews are away from base for an n-day trip. For example, the most senior crews get the shortest trips, such as two-day trips. 

# Aircraft

Aircraft can only be crewed by personnel who are trained on that specific aircraft type. For the purposes of this product, aircraft are characterized by the following properties. They have a registration and type. The type defines the number of passengers allowed and the type of training required for crewing.

# Database and API

The product should have a thoughtfully designed API to allow integration with other airline software used for flight planning, passenger booking etc. Data should be persisted to an external database, which should be expected to be remote in production. The design should be such that no information is lost if the program is closed unexpectedly.

# Reports

The product should be able to generate simple text or csv reports based on the information it handles. These could include reports of total scheduled hours, individual employee hours, pay information, or information about specific flights.

# Normal Operations

The standard way to use the program.

Flights are loaded from the database and initially have no crew assignment. The user should be able to select flights and be presented with possible crew assignments sorted based on a selectable term. For example, crew options may be presented with the closest crew first. For efficiency, assigning a crew should automatically also assign that crew to each successive flight on that aircraft, until the crew runs out of duty hours or have been returned to their base. Crew assignments should be assignable either as a one-time action or on a recurring basis. 

All changes to crew assignments must be recorded in the database with a human readable name that encodes the date of change and the flight affected. It is okay to track changes that violate the flight requirements in this table, but they should be labeled as invalid by some means. This may be useful to keep track of, because two invalid changes combined may put the affected flight in a valid state, such as switching the crew of one flight so the new crew can staff another flight at the destination.

In production we would receive notifications from other components of the overall airline scheduling infrastructure, such as flight planning and position reports. We can simulate these inputs with test mocks. The following events should be able to be simulated in this way:

- Receipt of actual departure or arrival times
- Updates to estimated departure or arrival times
- Flight cancellations
- Flight diversions
- Crewmember made unavailable unexpectedly

The program should notify the user if the crew schedule is broken by one of the above changes to the flight schedule. If a flight is delayed, the user should be notified immediately and standby crews automatically assigned if available.

# Misc

As far as schedule validity is concerned, airport standby crews are required to the degree necessary for any upcoming flight that day. For example, if no more aircraft will be departing from an airport, no standby crew is necessary. Standby crews must be scheduled before the first flight of the day is scheduled to depart.