import { Grid, List } from "semantic-ui-react";
import { Activity } from "../../../app/models/Activity";

interface Props {
  activities: Activity[];
}

export default function ActivityDashboard({ activities }: Props) {
  return (
    <Grid>
      <Grid.Column width="10">
        <List>
          {activities.map((activity: Activity) => (
            <List.Item key={activity.id}>
              {activity.id} - {activity.title}
            </List.Item>
          ))}
        </List>
      </Grid.Column>
    </Grid>
  );
}
