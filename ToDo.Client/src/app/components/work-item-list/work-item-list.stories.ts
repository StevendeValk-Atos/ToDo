import { HttpClientModule } from "@angular/common/http";
import { Meta, StoryObj, moduleMetadata } from "@storybook/angular";
import { fn } from "@storybook/test";

import { WorkItemService } from "../../work-item.service";
import { WorkItemListComponent } from "./work-item-list.component";
import { WorkItemDisplayComponent } from "../work-item-display/work-item-display.component";

const meta : Meta<WorkItemListComponent> = {
    title: "work-item-list",
    component: WorkItemListComponent,
    decorators: [
        moduleMetadata({
            imports: [HttpClientModule],
            providers: [WorkItemService],
            declarations: [ WorkItemDisplayComponent]
        })
    ]
};
export default meta;

type Story = StoryObj<WorkItemListComponent>;
export const Default: Story = {
    args: {
        workItems: [
                { id: 1, description: "Design a new logo for the company", isDone: false },
                { id: 2, description: "Update the company website with new content", isDone: true },
                { id: 3, description: "Create a marketing plan for the new product launch", isDone: false },
                { id: 4, description: "Write a user manual for the new software release", isDone: true },
                { id: 5, description: "Test the new feature in the software application", isDone: false },
                { id: 6, description: "Create training materials for the new software release", isDone: true },
                { id: 7, description: "Research new technology for use in the company's products", isDone: false },
                { id: 8, description: "Brainstorm and develop a new product concept for the company", isDone: true },
                { id: 9, description: "Develop a social media campaign to promote the company's products", isDone: false },
                { id: 10, description: "Develop a budget plan for the upcoming quarter", isDone: true },
        ]
    }
}