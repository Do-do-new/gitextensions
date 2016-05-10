using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GitCommands;

namespace GitUI.UserControls
{
    partial class RepoObjectsTree
    {
        /// <summary>Highlights or UN-highlights the specified <see cref="TreeNode"/> as a valid drop target.</summary>
        /// <param name="treeNode"><see cref="TreeNode"/> to highlight.</param>
        /// <param name="on">true to highlight, false to un-highlight.</param>
        static void Highlight(TreeNode treeNode, bool on = true)
        {
            treeNode.ForeColor = on ? Color.White : Color.Black;
            treeNode.BackColor = on ? Color.MediumPurple : new Color();
        }

        /// <summary>Occurs when a <see cref="TreeNode"/> is selected.</summary>
        void OnNodeSelected(object sender, TreeViewEventArgs e)
        {
            Node.OnNode<Node>(e.Node, node => node.OnSelected());
        }

        /// <summary>Occurs when a <see cref="TreeNode"/> is clicked.</summary>
        void OnNodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeMain.SelectedNode = e.Node;
            Node.OnNode<Node>(e.Node, node => node.OnClick());
        }

        /// <summary>Occurs when a <see cref="TreeNode"/> is double-clicked.
        /// <remarks>Expand/Collapse still executes for any node with children.</remarks></summary>
        void OnNodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // When folding/unfolding a node, e.Node won't be the one you double clicked, but a child node instead
            Node.OnNode<Node>(treeMain.SelectedNode, node => node.OnDoubleClick());
        }
    }
}
