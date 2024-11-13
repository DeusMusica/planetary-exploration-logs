import { MissionDto } from "../mission/mission-dto.model";
import { DiscoveryType } from "./discovery-type.model";

export interface Discovery {
    id: number;
    missionId: number;
    discoveryTypeId: number;
    name: string;
    description: string;
    location: string;
    mission: MissionDto;
    discoveryType: DiscoveryType;
  }
  