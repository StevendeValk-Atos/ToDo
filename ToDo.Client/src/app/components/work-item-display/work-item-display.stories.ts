import type { Meta, StoryObj} from "@storybook/angular";

import { fn } from "@storybook/test";

import { WorkItemDisplayComponent } from "./work-item-display.component";

const meta: Meta<WorkItemDisplayComponent> = {
    title: "work-item-display",
    component: WorkItemDisplayComponent
}

export default meta;
type Story = StoryObj<WorkItemDisplayComponent>;
export const Default: Story = {
    args: {
        workItem: {
            id: 1,
            description: "Prepare presentation",
            isDone: false
        }
    }
}
