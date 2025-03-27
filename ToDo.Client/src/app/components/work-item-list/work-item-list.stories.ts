import { HttpClientModule } from "@angular/common/http";
import {
    Meta,
    StoryObj,
    moduleMetadata,
    componentWrapperDecorator 
} from "@storybook/angular";
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
        }),
        componentWrapperDecorator((story) => {
            return `<div style="background-color: lightgray; padding: 1em; font-size: 1.5em;">${story}</div>`
        })
    ]
};
export default meta;

type Story = StoryObj<WorkItemListComponent>;
export const Default: Story = {
    args: {
        workItems: [
            {
                id: 1,
                description: "Design a new logo for the company",
                isDone: false,
                isMine: true
            },
            {
              id: 2,
              description: "Update the company website with new content",
              isDone: true,
              isMine: false
            },
            {
              id: 3,
              description: "Create a marketing plan for the new product launch",
              isDone: false,
              isMine: false
            },
            {
              id: 4,
              description: "Write a user manual for the new software release",
              isDone: true,
              isMine: true
            },
            {
              id: 5,
              description: "Test the new feature in the software application",
              isDone: false,
              isMine: false
            },
            {
              id: 6,
              description: "Create training materials for the new software release",
              isDone: true,
              isMine: false
            },
            {
              id: 7,
              description: "Research new technology for use in the company's products",
              isDone: false,
              isMine: false
            },
            {
              id: 8,
              description: "Brainstorm and develop a new product concept for the company",
              isDone: true,
              isMine: false
            },
            {
              id: 9,
              description: "Develop a social media campaign to promote the company's products",
              isDone: false,
              isMine: false
            },
            {
              id: 10,
              description: "Develop a budget plan for the upcoming quarter",
              isDone: false,
              isMine: false
            },
        ]
    }
}
